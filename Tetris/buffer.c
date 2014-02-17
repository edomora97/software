#include "buffer.h"

// stack abbastanza grande da contenere tutte le caselle (basterebbe uno stack
// di circa 4 elementi, ma per sicurezza...)
#define STACKSIZE 2000

// strct che contiene una modifica al buffer
typedef struct
{
	// posizione del carattere da modificare
	int x, y;
	// carattere da inserire
	char ch;
} edit;

typedef edit elem;

// stack del buffer
static elem stack[STACKSIZE];
// indice dell'ultimo elemento (-1 se è vuoto)
static int last = -1;

// inserisce un elemento nello stack
static void push(elem value);
// estrae un elemento dallo stack
static elem pop();

static void push(elem value)
{
	// se lo stack è pieno non fa nulla
	if (last >= STACKSIZE)
		return;
	// altrimenti incrementa l'indice dell'ultimo elemento e aggiunge il valore
	stack[++last] = value;
}
static elem pop()
{
	// ritorna l'ultimo elemento e decrementa l'indice
	return stack[last--];
}

void editBuffer(int x, int y, char ch)
{
	// crea una struct con le informazioni in input
	edit _edit;
	_edit.x = x;
	_edit.y = y;
	_edit.ch = ch;
	// inserisce l'elemento nello stack
	push(_edit);
}
void flush()
{
	// fintanto che ci sono elementi nello stack
	while (last >= 0)
	{
		// legge un elemento dallo stack
		elem curr = pop();
		// si sposta nella posizione adatta
		gotoxy(curr.x, curr.y);
		// stampa il carattere nello schermo
		printf("%c", curr.ch);
		// stampa il carattere nel buffer
		_model[curr.x][curr.y] = curr.ch;
	}
	// si sposta in una posizione fuori dalla board
	gotoxy(0,24);
}
void loadBuffer(char * path)
{
	// apre il file in lettura
	FILE * file = fopen(path, "r");
	int x, y;
	// scorre tutti i caratteri del file
	for (y = 0; y < HEIGHT; y++)
		for (x = 0; x < WIDTH; x++)
		{
			// legge un carattere
			char ch;			
			fscanf(file, "%c", &ch);
			// lo inserisce nel buffer
			_model[x][y] = ch;
			// lo stampa nello schermo
			printf("%c", _model[x][y]);
		}
	// cancella lo stack
	last = -1;
	// chiude il file
	fclose(file);
}
void clearBuffer()
{
	int x, y;
	// scorre tutto il buffer e lo cancella
	for (x = 0; x < WIDTH; x++)
		for (y = 0; y < HEIGHT; y++)
			_model[x][y] = ' ';
	// cancella anche lo stack
	last = -1;
}
void writeWithoutBuf(int x, int y, char buf[4][4], WORD color)
{
	// imposta il colore
	setColor(color);
	int _x, _y;
	// scorre tutto il buffer in input
	for (_x = 0; _x < 4; _x++)
		for (_y = 0; _y < 4; _y++)
		{
			// se il carattere è uno spazio oppure nello schermo in quella 
			// posizione non c'è uno spazio salta quel carattere
			if (buf[_x][_y] == ' ' || _model[x + _x][y + _y] != ' ')
				continue;
			// altrimenti si sposta il quel punto
			gotoxy(x + _x, y + _y);
			// stampa il carattere
			printf("%c", buf[_x][_y]);
		}
	// seimposta ilcolore a bianco
	setColor(FOREGROUND_BLUE | FOREGROUND_GREEN | FOREGROUND_RED);
}
void deleteWithoutBuf(int x, int y, char buf[4][4])
{
	int _x, _y;
	// scorre il buffer in input
	for (_x = 0; _x < 4; _x++)
		for (_y = 0; _y < 4; _y++)
		{
			// se il carattere è uno spazio non lo cancella cancella
			if (buf[_x][_y] == ' ')
				continue;
			// altrimenti si sposta in quel punto
			gotoxy(x + _x, y + _y);
			// stampa uno spazio
			printf(" ");
		}
}
void refresh()
{
	// esegue le modifiche dello stack
	flush();
	// si sposta all'inizio del terminale
	gotoxy(0,0);
	int x, y;
	// stampa tutto il buffer sopra allo schermo
	for (y = 0; y < HEIGHT; y++)
		for (x = 0; x < WIDTH; x++)
			printf("%c", _model[x][y]);
}
void setColor(WORD color)
{
	// usa una API di windows per impostare il colore
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), color);
}
void gotoxy(int x, int y)
{
	// usa una API di windows per spostare il cursore
	COORD coord = { x, y };
	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}
