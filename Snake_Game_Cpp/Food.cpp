#include "Food.h"
#include "Snake.h"

#define WIDTH 50
#define HEIGHT 25

void Food::gen_food()
{
	pos.X = rand() % (WIDTH  - 1 )+ 1; // 50 -> WIDTH
	pos.Y = rand() % (HEIGHT - 1) + 1; // 25 -> HEIGHT
}

COORD Food::get_pos() { return this->pos; }