#include <iostream>
#include <Windows.h>
#include <conio.h>
#include <thread>        
#include <chrono>
#include "Snake.h"
#include "Food.h"
#pragma warning(disable : 4996)

#define WIDTH 50
#define HEIGHT 25

using namespace std;

Snake snake({ WIDTH / 2, HEIGHT / 2 });
Food food;

void board()
{
	COORD snake_pos = snake.get_pos();
	COORD food_pos = food.get_pos();
	vector<COORD> snake_body = snake.get_body();

	cout << "Your score: " << snake.get_score() << endl;
	cout << endl;

	for (int y = 0; y < HEIGHT; ++y)
	{
		cout << "\t\t#";
		for (int x = 0; x < WIDTH; ++x)
		{
			if (y == 0 || y == HEIGHT - 1) cout << '#';

			else if (y == snake_pos.Y && x == snake_pos.X) cout << 'O';

			else if (y == food_pos.Y && x == food_pos.X) cout << '$';

			else
			{
				bool isBodyPart = false;

				for (int z = 0; z < snake_body.size() - 1; z++)
				{
					if (y == snake_body[z].Y && x == snake_body[z].X)
					{
						cout << 'o';
						isBodyPart = true;
						break;
					}
				}

				if (!isBodyPart) cout << ' ';
			}
		}
		cout << '#' << endl;
	}
}


int main()
{
	srand(NULL);

	food.gen_food();

	while (!snake.colided())
	{
		board();

		_sleep(snake.get_vel());

		if (kbhit())
		{
			snake.change_dir(getch());
		}

		// UNCOMMENT IF YOU WANT TO TAP EVERY MOVE
		//snake.change_dir(getch());

		snake.move_snake();

		if (snake.eaten(food.get_pos()))
		{
			food.gen_food();
		}

		/*if (snake.colided())
		{
			cout << "GAME OVER!!!";
			return 0;
		}*/ // UNCOMMENT IF YOU WANT TO LOSE WHEN HIT THE WALL

	   snake.return_snake_from_other_side();

		SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), { 0, 0 });
	}
}
