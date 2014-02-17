#include<stdio.h>
#include<stdlib.h>
#include<conio.h>
#include "Windows.h"

#define WIDTH 80
#define HEIGHT 24
#define SLEEP 100

char model[WIDTH][HEIGHT];
int board[9][9];
FILE *file;
int curX, curY;
int playing;
int winned;
int first;

int width, height;
int minX, minY;
int numFiori;

void printModel();
void initialize();
void generateBoard();
void input();
void apriCasella(int x, int y);
void checkWin();
void setColor(int color);
void gotoxy(int x, int y);
