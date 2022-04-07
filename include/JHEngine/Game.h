#ifndef GAME_H
#define GAME_H

#include <SDL.h>

class Game{
    public:
        SDL_Renderer* gRenderer;
        SDL_Window* gWindow;
        const Uint8* input;
        
        int GetHeight();
        int GetWidth();
        Game();
        Game(int width,int height);
        ~Game();
        virtual void Init(const char* name);
        virtual bool Update();
        virtual void Draw();
        virtual void Close();
    protected:
        int m_width, m_height;
};


#endif