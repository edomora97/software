#include "main.h"

int main(int argc, char *argv[]) 
{
	// inizializza il gioco
	initialize();
	// ciclo del gioco
	while (playing)
	{
		// stampa il modello
		printModel();
		// verifica l'input
		input();
		// verifica la vittoria
		checkWin();
		// aspetta un tot
		Sleep(SLEEP);
	}
	int x, y;
	setColor(FOREGROUND_RED);
	for (x = 0; x < width; x++)
		for (y = 0; y < height; y++)
		{
			// Mostra la posizione di tutti i fiori
			if (board[x][y] == 0)
			{
				gotoxy(x + minX - 1, y + minY + 1);
				printf("*");
			}
		}
	setColor(FOREGROUND_INTENSITY);
	// sposta il cursore alla fine della console
	gotoxy(0, 24);
	
	printf("FINE...");
	if (winned)
		printf(" HAI VINTO!");
	else
		printf(" HAI PERSO!");		
	
	getch();
	return 0;
}
// stampa il contenuto del modello
void printModel()
{
	// pulisce lo schermo
	system("cls");
	int i, j;
	// scorre tutti i caratteri e li stampa
	for (i = 0; i < HEIGHT; i++)
		for (j = 0; j < WIDTH; j++)
		{
			char ch = model[j][i];
			if (ch == '°')
				setColor(FOREGROUND_GREEN);
			if (ch == 'o')
				setColor(FOREGROUND_BLUE);
			printf("%c", model[j][i]);
			setColor(FOREGROUND_INTENSITY);
		}
	// risposta il cursore al punto precedente
	gotoxy(curX, curY);
}
// inizializza il gioco
void initialize()
{	
	// apre il file della board
	file = fopen("board9x9.txt", "r");
	fscanf(file, "%d", &width);
	fscanf(file, "%d", &height);
	fscanf(file, "%d", &minX);
	fscanf(file, "%d", &minY);
	fscanf(file, "%d", &numFiori);
	
	int i, j;
	// scorre tutti i caratteri del modello e li legge dal file
	for (i = 0; i < HEIGHT; i++)
		for (j = 0; j < WIDTH; j++)
			fscanf(file, "%c", &model[j][i]);
	// chiude il file
	fclose(file);
	// imposta la posizione del cursore
	curX = minX-1;
	curY = minY+1;
	playing = 1;
	first = 1;
	// imposta il colore: testo giallo sfondo grigio
	system("color 8");
}
// genera la griglia del gioco
void generateBoard()
{
	// imposta il generatore dei numeri casuali
	srand(time(0));
	int i;
	int j;
	// pulisce la tabella
	for (i=0;i<height;i++)
		for(j=0;j<width;j++)
			board[j][i] = -1;
	// Posiziona i fiori
	for (i = 0; i < numFiori; i++)
	{
		int x, y;
		x = rand() % width;
		y = rand() % height;
		// se il blocco è occupato oppure è la posizione corrente
		while (board[x][y] == 0 || (x == curX - minX && y == curY - minY))
		{
			// rigenera i blocchi
			x = rand() % width;
			y = rand() % height;
		}
		board[x][y] = 0;
	}
	// Posiziona i numeri
	for (i = 0; i < width; i++)
	{
		for (j = 0; j < height; j++)
		{
			// se è un fiore non ci vanno numeri
			if (board[i][j] == 0)
				continue;
			int count = 0;
			// conta attorno alla casella quanti fiori ci sono
			if (i+1<width&&board[i+1][j]==0)
				count++;
			if (i+1<width&&j+1<height&&board[i+1][j+1]==0)
				count++;
			if (j+1<height&&board[i][j+1]==0)
				count++;
			if (i-1>=0&&j+1<height&&board[i-1][j+1]==0)
				count++;
			if (i-1>=0&&board[i-1][j]==0)
				count++;
			if (i-1>=0&&j-1>=0&&board[i-1][j-1]==0)
				count++;
			if (j-1>=0&&board[i][j-1]==0)
				count++;
			if (i+1<width&&j-1>=0&&board[i+1][j-1]==0)
				count++;
			
			// se non ci sono fiori imposta -1 altrimenti il numero di fiori
			if (count == 0)
				board[i][j] = -1;
			else
				board[i][j] = count;
		}
	}
	// ------- DEBUG: stampa la board in un file ------
	FILE *out;
	out = fopen("board.txt", "w");
	// salva la tabella del gioco in un file
	for (i=0; i < height; i++)
	{
		for (j = 0; j<width;j++)
		{
			// se è un fiore stampa *
			if (board[j][i] == 0)
				fprintf(out, "* ");
			// se non è un numero stampa o
			else if (board[j][i] == -1)
				fprintf(out, "o ");
			// altrimenti stampa il numero
			else
				fprintf(out, "%d ", board[j][i]);
		}
		// manda a capo ad ogni riga
		fprintf(out, "\n");
	}
	fclose(out);
}
// verifica l'input
void input()
{
	// se sono stati premuti dei tasti
	if (kbhit())
	{
		// il tasto premuto
		int key = getch();
		switch (key)
		{
			case 72:	// UP
				if (curY-1>=minY+1)
					curY--;
				break;
			case 75:	// LEFT
				if (curX-1>=minX-1)
					curX--;
				break;
			case 80:	// DOWN
				if (curY+1<minY+height+1)
					curY++;
				break;
			case 77:	// RIGHT
				if (curX+1<minX+width-1)
					curX++;
				break;
			case 'b':	// APRI
				if (first)
				{
					generateBoard();
					first = 0;
				}
				if (model[curX+1][curY-1] == ' ')
					apriCasella(curX - minX + 1, curY - minY -1);
				break;
			case 'a':	// BANDIERA
				if (model[curX+1][curY-1] == ' ')
					{ model[curX+1][curY-1] = '°'; break; }		// ° = campitura (terminal)
				if (model[curX+1][curY-1] == '°')
					{ model[curX+1][curY-1] = ' '; break; }
		}
	}
}
// apre la clasella
void apriCasella(int x, int y)
{
	// se è già stata aperta non fare nulla
	if (model[x+minX][y+minY]=='o')
		return;
	// se è un fiore il gioco finisce
	if (board[x][y] == 0)
		playing = 0;
	// se è un numero, mostra il numero
	else if (board[x][y] != -1)
		model[x + minX][y + minY] = board[x][y] + 48;
	// se non è un numero avvia un processo ricorsivo che apre tutte le 
	// caselle attorno
	else
	{
		// segna la clasella come aperta
		model[x+minX][y+minY] = 'o';
		// apre tutte le casella attorno (ricorsivo)
		if (x>0)
			apriCasella(x-1, y);
		if (x>0&&y>0)
			apriCasella(x-1, y-1);
		if (y>0)
			apriCasella(x, y-1);
		if (x<width-1&&y>0)
			apriCasella(x+1, y-1);
		if (x<width-1)
			apriCasella(x+1, y);
		if (x<width-1&&y<height-1)
			apriCasella(x+1, y+1);
		if (y<height-1)
			apriCasella(x, y+1);
		if (x>0&&y<height-1)
			apriCasella(x-1, y+1);
	}	
}
// controlla se il giocatore ha vinto
void checkWin()
{
	// se è il primo turno non ha vinto...
	if (first)
		return;
	// si considera che il giocatore non ha perso
	int win = 1;
	int i, j;
	// scorre tutte le caselle
	for (i = 0; i < width; i++)
		for (j=0;j<height;j++)
		{
			// se una casella che non è un fiore è ancora scoperta
			// non si ha vinto
			if (board[i][j] != 0 && model[i+minX][j+minY]==' ')
			{
				// il giocatore non ha vinto
				win = 0;		
				// esce dai due cicli		
				goto ExitFromTheLoops;
			}
		}
	// Poco ortodosso ma funziona...
	ExitFromTheLoops:
	// se il giocatore ha vinto		
	if (win)
	{			
		// allora il gioco finisce
		playing = 0;
		winned = 1;
	}
}
// imposta il colore del testo
void setColor(int color)
{
	HANDLE hConsole;
	hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hConsole, color);
}
void gotoxy(int x, int y)
{
	COORD coord = { x, y};
	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}
