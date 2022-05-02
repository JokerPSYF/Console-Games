#include "Snake.h"
#include <vector>

#define WIDTH 50
#define HEIGHT 25

Snake::Snake(COORD pos)
{
	this->pos = pos;
	this->vel = 200;
	len = 1;
	score = 0;
	direction = 'n';
	body.push_back(this->pos);
}

void Snake::change_dir(char dir)
{
	if (dir == 'w'
		|| dir == 's'
		|| dir == 'd'
		|| dir == 'a'
		|| dir == 'W'
		|| dir == 'S'
		|| dir == 'D'
		|| dir == 'A'
		|| dir == 72
		|| dir == 80
		|| dir == 77
		|| dir == 75)
	{
		direction = dir;
	}
}

void Snake::grow() { len++; }

vector<COORD> Snake::get_body() { return body; }

void Snake::move_snake()
{
	switch (direction)
	{
	case 'w': case 'W': case 72: pos.Y--; break;
	case 's': case 'S': case 80: pos.Y++; break;
	case 'd': case 'D': case 77: pos.X++; break;
	case 'a': case 'A': case 75: pos.X--; break;
	}

	body.push_back(pos);

	if (int(body.size()) > int(len))
	{
		body.erase(body.begin());
	}
}


COORD Snake::get_pos() { return pos; }

bool Snake::eaten(COORD food_pos)
{
	if (food_pos.X == this->pos.X && food_pos.Y == this->pos.Y)
	{
		vel -= 10;
		if (vel < 0) vel = 0;
		score_increased();
		this->grow();
		return true;
	}
	return false;
}

// UNCOMMENT IF YOU WANT TO LOSE WHEN HIT THE WALL
bool Snake::colided()
{
	if (this->pos.X < 0 ||
		this->pos.X >= WIDTH - 1 ||
		pos.Y <= 0 ||
		pos.Y >= HEIGHT - 1)
		return true;

	else return false;
}

void Snake::return_snake_from_other_side()
{
	if (pos.X < 0)
	{
		pos.X = WIDTH - 1;
	}
	else if (pos.X > WIDTH - 1)
	{
		pos.X = 0;
	}
	else if (pos.Y <= 0)
	{
		pos.Y = HEIGHT - 2;
	}
	else if (pos.Y >= HEIGHT - 1)
	{
		pos.Y = 1;
	}
}

void Snake::score_increased() { score++; }

int Snake::get_score() { return score; }

int Snake::get_vel() { return this->vel; }