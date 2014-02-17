#include "main.h"
#include <windows.h>

#define SLEEP 300

int main() 
{
    // pulisce il buffer (inutile ma non si sa mai...)
	clearBuffer();
	// carica il buffer dal file board
	loadBuffer("board.txt");
	// prepaea il generatore di numeri casuali
	srand(time(0));
	
	// da il via al gioco creando i due blocchi per i giocatori
	newBlock_A();
	newBlock_B();
	
	// Fintanto che almeno un giocatore è in gioco
	while (playing_A || playing_B)
	{
        // legge l'input
		input();
        // se il primo giocatore sta giocando
		if (playing_A)
		{
            // aggiorna la sua posizione          
			update_A();
			// esegue il disegno del suo blocco
			draw_A();
		}
		// se il secondo giocatore sta giocando
		if (playing_B)
		{
            // aggiorna la sua posizione          
			update_B();
			// esegue il disegno del suo blocco
			draw_B();
		}
		// ristampa il punteggio
		writeScore();
		// aspetta un po'...
		Sleep(SLEEP);
	}
	// Quando entrambi i giocatori hanno perso
	// Sposta il cursore in un posto adatto a stampare
	gotoxy(0, 24);
	// stampa i messaggio finali come il giocatore che ha vinto
	printf("FINE! ");
	printf("IL GIOCATORE %c HA VINTO!!", punteggio_A > punteggio_B ? 'A' : 'B');
	// aspetta che venga premuto un tasto per uscire
	getch();
	return 0;
}

int chkColl_A(int dX, int dY)
{
	int x, y;
	int found = 0;
	// scorre il buffer del blocco del giocatore a
	for (x = 0; x < 4; x++)
		for (y = 0; y < 4; y++)
		{
            // a è il carattere nel buffer del blocco
			char a = buf_A.buf[x][y];
			// b è il carattere nel buffer della board e dei blocco sotto
			char b = _model[buf_A.x + x + dX][buf_A.y + y + dY];
			// se uno dei due caratteri è vuoto ignora e passa avanti
			if (a == ' ' || b == ' ')			
				continue;
			// se nessuno dei due è vuoto allora c'è una collisione
			found = 1;
		}
	// ritorna 0 se non c'è collisione, altrimenti 1
	return found;
}
int chkColl_B(int dX, int dY)	// 1 = found 0 = not found
{
	// stesso identico funzionamento di chkColl_A()
	
	int x, y;
	int found = 0;
	for (x = 0; x < 4; x++)
		for (y = 0; y < 4; y++)
		{
			char a = buf_B.buf[x][y];
			char b = _model[buf_B.x + x + dX][buf_B.y + y + dY];
			if (a == ' ' || b == ' ')
				continue;
			found = 1;
		}
	return found;
}
void input()
{
	int x, y;
	buf_P temp;
	// fintanto che c'è un tasto premuto (nel suo buffer)
	while(kbhit())
	{
        // legge quel carattere          
		char ch = getch();
		switch (ch)
		{
            // Se viene premuta la sinistra del giocatore A
			case 'a':
			case 'A':
                // cancella il blocco dallo schermo
				deleteWithoutBuf(buf_A.x,buf_A.y, buf_A.buf);
				// se non collide sposta il blocco a sinistra di uno
				if (!chkColl_A(-1, 0))
					buf_A.x--;
				break;
			// Se viene premuta la destra del giocatore A
			case 's':
			case 'S':
                // cancella il blocco dallo schermo
				deleteWithoutBuf(buf_A.x,buf_A.y, buf_A.buf);
				// se non collide sposta il blocco a destra di uno
				if (!chkColl_A(1, 0))
					buf_A.x++;
				break;	
            // se viene premuto il ruota-blocco del giocatore A		
			case 'x':
			case 'X':
                // cancella il blocco dallo schermo
				deleteWithoutBuf(buf_A.x,buf_A.y, buf_A.buf);
				// salva una copia di backup
				temp = buf_A;
				// ruota il blocco
				buf_A.id = next(buf_A.id);
				// genera il buffer del nuovo blocco
				generateBlock(buf_A.id);
				// copia il buffer nel buffer del blocco
				memcpy(&buf_A.buf, &block, sizeof(char) * 16);
				// se la nuova posizione è in collisione, non si può ruotare e
                // ripristina la copia
				if (chkColl_A(0,0))
					buf_A = temp;
				break;
			// Se viene premuta la sinistra del giocatore B
			case 'j':
			case 'J':
                // cancella il blocco dallo schermo
				deleteWithoutBuf(buf_B.x,buf_B.y, buf_B.buf);
				// se non collide sposta il blocco a sinistra di uno
				if (!chkColl_B(-1, 0))
					buf_B.x--;
				break;
			// Se viene premuta la destra del giocatore B
			case 'k':
			case 'K':
                // cancella il blocco dallo schermo
				deleteWithoutBuf(buf_B.x,buf_B.y, buf_B.buf);
				// se non collide sposta il blocco a destra di uno
				if (!chkColl_B(1, 0))
					buf_B.x++;
				break;			
            // se viene premuto il ruota-blocco del giocatore A
			case 'm':
			case 'M':
                 // cancella il blocco dallo schermo
				deleteWithoutBuf(buf_B.x,buf_B.y, buf_B.buf);
				// salva una copia di backup
				temp = buf_B;
				// ruota il blocco
				buf_B.id = next(buf_B.id);
				// genera il buffer del nuovo blocco
				generateBlock(buf_B.id);
				// copia il buffer nel buffer del blocco
				memcpy(&buf_B.buf, &block, sizeof(char) * 16);
				// se la nuova posizione è in collisione, non si può ruotare e
                // ripristina la copia
				if (chkColl_B(0,0))
					buf_B = temp;
				break;
		}
	}
}
void draw_A()
{
    // disegna il blocco senza usare il buffer, di colore verde e nella 
	// posizione corretta
	writeWithoutBuf(buf_A.x, buf_A.y, buf_A.buf, FOREGROUND_GREEN);
}
void draw_B()
{
	// disegna il blocco senza usare il buffer, di colore verde e nella 
	// posizione corretta
	writeWithoutBuf(buf_B.x, buf_B.y, buf_B.buf, FOREGROUND_GREEN);
}
void update_A()
{
	// cancella il blocco dallo schermo
	deleteWithoutBuf(buf_A.x,buf_A.y, buf_A.buf);
	// se abbassandolo di uno non collide allora sposta il blocco
	if (!chkColl_A(0, 1))
		buf_A.y++;
	// altrimenti genera un nuovo blocco perchè non si può più scendere
	else
		newBlock_A();
	
	// controlla se deve essere cancellata una riga
	int x, y;
	// scorre tutte le righe partendo dall'ultima in basso
	for (y = 20; y > 4; y--)
	{
		// scorre tutte le colonne di quella riga
		for (x = 17; x < 26; x++)
			// se viene trovato un buco esce dal ciclo senza fare nulla
			if (_model[x][y] == ' ')
				goto Exit;		
		// se non ci sono buchi allora la riga è piena, sposta in basso tutti 
		// i blocchi sopra
		int _y;
		// scorre tutte le righe partendo da y e ci ricopia la riga sopra 
		// (nel buffer)
		for (_y = y; _y > 4; _y--)
			for (x = 17; x < 26; x++)
				_model[x][_y] = _model[x][_y-1];
		// è necesserio ripetere il controllo sulla riga corrente
		// per ingannare il ciclo for si incremeta y (poi verrà decrementato) e
		// si ripeterà il controllo
		y++;
		// aggiorna il buffer dello schermo ridisegnando tutto
		refresh();		
		Exit:
		// serve solo per far funzionare l'etichetta...
		continue;
	}
}
void update_B()
{
	// stesso identico funzionamento di update_A()
	
	deleteWithoutBuf(buf_B.x,buf_B.y, buf_B.buf);
	if (!chkColl_B(0, 1))
		buf_B.y++;
	else
		newBlock_B();
		int x, y;
	for (y = 20; y > 4; y--)
	{
		for (x = 50; x < 59; x++)
			if (_model[x][y] == ' ')
				goto Exit;		
		int _y;
		for (_y = y; _y > 4; _y--)
			for (x = 50; x < 59; x++)
				_model[x][_y] = _model[x][_y-1];
		y++;
		refresh();
		Exit:
		continue;
	}
}
void newBlock_A()
{
	// se si generà un nuovo blocco allora si deve rendere fisso quello
	// precedente stampandolo sul buffer
	int x, y;
	for (x = 0; x < 4; x++)
		for (y = 0; y < 4; y++)
			// stampa solo i caratteri diversi dallo spazio
			if (buf_A.buf[x][y] != ' ')
				// aggiunge il carattere nello stack del buffer
				editBuffer(buf_A.x + x, buf_A.y + y, buf_A.buf[x][y]);
	// svuota lo stack e rende definitivo il buffer
	flush();
	
	// genera a caso le coordinate ed il tipo di blocco	
	buf_A.x = rand() % 5 + 17;
	buf_A.y = 4;
	buf_A.id = rand() % 15;
	// costruisce il bufferd del blocco
	generateBlock(buf_A.id);
	// copia il buffer del blocco
	memcpy(&buf_A.buf, &block, sizeof(char) * 16);
	// controlla se il blocco collide, in questo caso il gioco finisce
	if (chkColl_A(0,0))
		playing_A = 0;
	// il punteggio viene incrementato perchè si ha generato un nuovo blocco
	punteggio_A++;
}
void newBlock_B()
{
	// stesso identico funzionamento di newBlock_A()
	
	int x, y;
	for (x = 0; x < 4; x++)
		for (y = 0; y < 4; y++)
			if (buf_B.buf[x][y] != ' ')
				editBuffer(buf_B.x + x, buf_B.y + y, buf_B.buf[x][y]);
	flush();
	
	buf_B.x = rand() % 5 + 50;
	buf_B.y = 4;
	buf_B.id = rand() % 15;
	generateBlock(buf_B.id);
	memcpy(&buf_B.buf, &block, sizeof(char) * 16);
	if (chkColl_B(0,0))
		playing_B = 0;
	punteggio_B++;
}
void writeScore()
{	
	// se stà vincendo il giocatore A il suo punteggio sarà verde
	if (punteggio_A > punteggio_B)
		setColor(FOREGROUND_GREEN);
	// se invecie vince B il suo punteggio sarà rosso
	else if (punteggio_A < punteggio_B)
		setColor(FOREGROUND_RED);
	// sposta il cursore nella posizione dova andrà stampato il punteggio
	gotoxy(27, 22);
	// se la partita non è finita stampa solo il punteggio
	if (playing_A)
		printf("%d", punteggio_A);
	// altrimenti stampa anche il marcatore di fine partita
	else
		printf("%d FINE", punteggio_A);
		
	// stesso ragionamento per il secondo giocatore
	if (punteggio_A > punteggio_B)
		setColor(FOREGROUND_RED);
	else if (punteggio_A < punteggio_B)
		setColor(FOREGROUND_GREEN);
	gotoxy(60, 22);
	if (playing_B)
		printf("%d", punteggio_B);
	else
		printf("%d FINE", punteggio_B);
		
	// reimposta il colore della console a bianco
	setColor(FOREGROUND_BLUE | FOREGROUND_GREEN | FOREGROUND_RED);
}
