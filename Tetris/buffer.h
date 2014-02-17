#include <stdlib.h>
#include <windows.h>
#include <stdio.h>

#define WIDTH 80
#define HEIGHT 24

// il buffer
char _model[WIDTH][HEIGHT];

// esegue una modifica al buffer
void editBuffer(int x, int y, char ch);
// stampa un blocco nello schermo senza il buffer e del colore scelto
void writeWithoutBuf(int x, int y, char buf[4][4], WORD color);
// cancella dallo schermo il blocco
void deleteWithoutBuf(int x, int y, char buf[4][4]);
// svuota lo stack e modifica il buffer
void flush();
// carica il buffer da un file
void loadBuffer(char * path);
// cancella il buffer
void clearBuffer();
// aggiorna lo schermo con il contenuto del buffer
void refresh();
// usa una API di windows per modificare il colore
void setColor(WORD color);
// usa una API di windows per modificare la posizione del cursore
void gotoxy(int x, int y);
