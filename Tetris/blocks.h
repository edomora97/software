// carattere per il blocco
#define BLOCK 'þ'

// buffer temporaneo che contiene il blocco dopo un generateBlock(id)
char block[4][4];

//genera il buffer del blocco con l'id specificato
void generateBlock(int id)
{
	int x, y;
	// pulisce il buffer
	for (x=0;x<4;x++)
		for(y=0;y<4;y++)
			block[x][y] = ' ';
	// esegue una selezione in base all'id del blocco
	// posiziona nel buffer i pezzi del tetramino
	switch (id)
	{
		case 0: block[0][0]=BLOCK; block[1][1]=BLOCK; block[1][0]=BLOCK; block[0][1]=BLOCK; break;
		case 1: block[0][0]=BLOCK; block[0][1]=BLOCK; block[0][2]=BLOCK; block[0][3]=BLOCK; break;
		case 2: block[0][0]=BLOCK; block[1][0]=BLOCK; block[2][0]=BLOCK; block[3][0]=BLOCK; break;
		case 3: block[0][0]=BLOCK; block[0][1]=BLOCK; block[1][1]=BLOCK; block[1][2]=BLOCK; break;
		case 4: block[0][1]=BLOCK; block[1][1]=BLOCK; block[1][0]=BLOCK; block[2][0]=BLOCK; break;
		case 5: block[1][0]=BLOCK; block[1][1]=BLOCK; block[0][1]=BLOCK; block[0][2]=BLOCK; break;
		case 6: block[0][0]=BLOCK; block[1][0]=BLOCK; block[1][1]=BLOCK; block[2][1]=BLOCK; break;
		case 7: block[0][0]=BLOCK; block[1][0]=BLOCK; block[1][1]=BLOCK; block[1][2]=BLOCK; break;
		case 8: block[0][0]=BLOCK; block[1][0]=BLOCK; block[2][0]=BLOCK; block[0][1]=BLOCK; break;
		case 9: block[0][0]=BLOCK; block[0][1]=BLOCK; block[0][2]=BLOCK; block[1][2]=BLOCK; break;
		case 10: block[0][1]=BLOCK; block[1][1]=BLOCK; block[2][1]=BLOCK; block[2][0]=BLOCK; break;
		case 11: block[0][0]=BLOCK; block[1][0]=BLOCK; block[0][1]=BLOCK; block[0][2]=BLOCK; break;
		case 12: block[0][0]=BLOCK; block[1][0]=BLOCK; block[2][0]=BLOCK; block[2][1]=BLOCK; break;
		case 13: block[1][0]=BLOCK; block[1][1]=BLOCK; block[1][2]=BLOCK; block[0][2]=BLOCK; break;
		case 14: block[0][0]=BLOCK; block[0][1]=BLOCK; block[1][1]=BLOCK; block[2][1]=BLOCK; break;
		default: return;
	}
}
// ottiene l'id del blocco successivo a quello con l'id in input
int next(int id)
{
	if (id == 0) return 0;
	else if (id == 1) return 2;
	else if (id == 2) return 1;
	else if (id == 3) return 4;
	else if (id == 4) return 3;
	else if (id == 5) return 6;
	else if (id == 6) return 5;
	else if (id == 7) return 8;
	else if (id == 8) return 9;
	else if (id == 9) return 10;
	else if (id == 10) return 7;
	else if (id == 11) return 12;
	else if (id == 12) return 13;
	else if (id == 13) return 14;
	else if (id == 14) return 11;
	else return -1;	
}
