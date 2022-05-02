#ifndef FOOD_H
#define FOOD_H

#include <windows.h>
#include <cstdlib>

class Food
{
private:
	COORD pos;

public:
	void gen_food(); // generate food
	COORD get_pos(); // get position of the food
};

#endif

