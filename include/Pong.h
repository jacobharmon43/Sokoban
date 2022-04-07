#ifndef PONG_H
#define PONG_H

#include <iostream>
#include "Game.h"
#include "Object.h"
#include "Vector2Int.h"
#include "Dynamic.h"

class Pong : public Game{
    public:
        Pong();
        Pong(int width, int height);
        ~Pong();
        void Init(const char* name);
        bool Update();
        void Draw();
        void Close();
    private:
        Object m_player1;
        Object m_player2;
        Dynamic* m_ball;
        Object m_divider;
        int m_speed;
        bool PollKeyboard(const Uint8* input);
};

#endif