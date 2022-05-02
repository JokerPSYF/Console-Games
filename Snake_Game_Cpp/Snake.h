#ifndef SNAKE_H
#define SNAKE_H

#include <vector>
#include <windows.h>

using namespace std;

class Snake
{
private:
	COORD pos;	
	int len;
	int vel;
	int score;
	char direction;
	vector<COORD> body;
	

public:
	Snake(COORD pos); // create new snake

	void change_dir(char dir); // change the diraction of the snake

	void move_snake(); // move the direction of the snake

	COORD get_pos(); // Get the position of hte snake

	vector<COORD> get_body();

	bool eaten(COORD food_pos); //Check if snake eat the food

	void grow(); // grow the snake

	bool colided(); // check if the snake is out of the map

	void return_snake_from_other_side(); // if the snake is out of the map then returned from the other side like pac-man

	void score_increased();

	int get_score();

	int get_vel();
};
#endif
