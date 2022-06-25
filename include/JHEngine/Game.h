#ifndef GAME_H
#define GAME_H

#include <SDL.h>
#include <SDL_image.h>

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
        virtual bool Update(double deltaTime);
        virtual void Draw();
        virtual void Close();
    protected:
        int m_width, m_height;
};


#endif