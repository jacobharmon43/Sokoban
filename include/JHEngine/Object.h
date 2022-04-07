#ifndef OBJECT_H
#define OBJECT_H

#include <SDL.h>
#include "Vector2Int.h"
#include "Vector2.h"
#include "Rectangle.h"

class Object{
    public:
        Object();
        Object(Rectangle renderPosition, SDL_Color renderColor, int renderOrder);
        ~Object();
        virtual void Render(SDL_Renderer* r);
        void Move(Vector2 move);
        void SetScale(Vector2Int set);
        Vector2 GetPos();
        Vector2Int GetScale();
        Rectangle GetRect();
    protected:
        Rectangle m_renderPosition;
        SDL_Color m_renderColor;
        int m_renderOrder;
        
};

#endif