// Fisica.cpp : definisce il punto di ingresso dell'applicazione console.
//

#include "stdafx.h"
#include <iostream>
#include <cmath>
#include <cstdio>
#define PI 3.14159265f

using namespace std;

float CalcolaPeso(float massa, float gravita)
{
     float temp = massa * gravita;
     return temp;
}

float CalcolaRadianti(float gradi)
{
	float temp = gradi*PI/180;
	return temp;
}

float CalcolaCosenoGrad(float angoloGrad)
{
	float temp;
	temp = sin(CalcolaRadianti(angoloGrad));
	return temp;
}

float CalcolaCosenoRad(float angoloRad)
{
	float temp = angoloRad;
	temp = cos(temp);
	return temp;
}

float Peso(bool silent, float _massa)
{
	float gravita, massa, peso;
	int index2;
	bool OK;
	if (!silent)
		cout << "\n\nHai scielto di calcolare il peso!" << endl << endl;
	cout << "La gravita' e' 9.81 m/s^2? " << endl << "0 = NO / 1 = SI" << endl;
	cin >> index2;

	switch (index2)
	{		
		case 0: 
		{
			cout << "\nInserisci la gravita' in m/s^2: " << endl;
			cin >> gravita;
			OK = true;
			break;
		}
		case 1:
		{
			gravita = 9.81f;
			OK = true;
			break;
		}		
		default:
		{
			cout << "Comando non valido" << endl;
			system("PAUSE");
			exit(1);
		}
	}

	if(OK && !silent)
	{
		cout << "Inserisci la massa (Kg): ";
		cin >> massa;
		peso = massa * gravita;
		cout << "Il peso e': " << peso << " N" << endl;
		return peso;
	}
	if (OK && silent)
	{
		peso = _massa * gravita;
		return peso;
	}
	return peso;
}

void Attrito()
{
	float peso, massa, alpha, forza, lunghezza, altezza;
	bool OK;
	int index2, index3;
	cout << "Conosci il peso (0) o la massa (1) ?" << endl;
	cin >> index2;
	switch (index2)
	{
		case 0:
			{
				cout << "Inserisci il peso(N): ";
				cin >> peso;
				OK = true;
				break;
			}
		case 1:
			{
				cout << "Inserisci la massa (Kg): ";
				cin >> massa;
				peso = Peso(true, massa);
				OK = true;
				break;
			}						
		default:
			{
				cout << "Comando non valido" << endl;
				system("PAUSE");
				exit(1);
			}
	}
	if (OK)
	{
		cout << "Conosci l'angolo in gradi (0), l'angolo in radianti(1) o l'altezza/lunghezza(2)?";
		cin >> index3;
		switch (index3)
		{
			case 0:
			{
				cout << "Inserisci l'angolo in gradi: ";
				cin >> alpha;
				forza = peso * CalcolaCosenoGrad(alpha);
				cout << "L'attrito e': " << forza << " N" << endl;
				break;
			}
			case 1:
			{
				cout << "Inserisci l'angolo in radianti: ";
				cin >> alpha;
				forza = peso * CalcolaCosenoRad(alpha);
				cout << "L'attrito e': " << forza << " N" << endl;
				break;
			}
			case 2:
			{
				cout << "Inserisci la lunghezza: ";
				cin >> lunghezza;
				cout << "Inserisci l'altezza: ";
				cin >> altezza;
				forza = peso * (altezza/lunghezza);
				cout << "L'attrito e': " << forza << " N" << endl;
				break;
			}
			default:
			{
				cout << "Comando non valido" << endl;
				exit(1);
			}
		}
	}
}

int main(int argc, char *argv[])
{
    //Variabili
    int index1;
    
	while (true)
	{
		cout << "COLLABORATORE DI FISICA by Edoardo" << endl;
		cout << "Da non utilizzare per fare i compiti ma solo per controllarli!!" << endl << endl;
		cout << "Cosa vuoi fare? " << endl;
		cout << "0. Esci" << endl;
		cout << "1. Calcolare il peso" << endl;
		cout << "2. Calcolare la forza attrito" << endl;

		cin >> index1;

		switch (index1)
		{
			case 0:
			{
				return EXIT_SUCCESS;
				break;
			}
			case 1:
			{
				Peso(false, 0);
				break;
			}
			case 2:
			{
				Attrito();
				break;
			}
			default:
			{
				cout << "Comando non valido" << endl;
				system("PAUSE");
				exit(1);
			}
		}
		system("PAUSE");
		system("cls");
	}
}

