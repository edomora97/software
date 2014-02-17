#include "buffer.h"
#include "blocks.h"

// struttura che indica il buffer del blocco che scende
typedef struct
{
	// le sue coordinate
	int x, y;
	// il suo tipo
	int id;
	// e ovviamente il suo buffer
	char buf[4][4];
} buf_P;

// il blocco del primo giocatore
buf_P buf_A;
// il blocco del secondo giocatore
buf_P buf_B;
// flag che indicano lo stato della partita
int playing_A = 1, playing_B = 1;
// i punteggi dei giocatori
int punteggio_A = 0, punteggio_B = 0;

// controlla se il blocco di A colliderebbe se si muovesse di dX e dY
int  chkColl_A(int dX, int dY);
// controlla se il blocco di B colliderebbe se si muovesse di dX e dY
int  chkColl_B(int dX, int dY);
// esegue il controllo dell'input
void input();
// stampa i punteggi dei giocatori
void writeScore();

// disegna il blocco di A
void draw_A();
// aggiorna lo stato di A
void update_A();
// genera un nuovo blocco per A
void newBlock_A();

// disegna il blocco di B
void draw_B();
// aggiorna lo stato di B
void update_B();
// genera un nuovo blocco per A
void newBlock_B();
