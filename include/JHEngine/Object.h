// Jacob Harmon
// Object base class meant to handle basic renderering and placement capabilities of all objects.

#ifndef OBJECT_H
#define OBJECT_H

#include <SDL.h>
#include "Vector2Int.h"
#include "Vector2.h"
#include "Rectangle.h"

class Object{
    public:
        int m_renderOrder;
        SDL_Color m_renderColor;
        SDL_Texture* m_texture;
        //* Constructors *//
        Object();
        Object(SDL_Texture* t, Rectangle renderPosition, SDL_Color renderColor, int renderOrder, float rotation = 0);
        ~Object();
        
        //* Getters *//
        Rectangle GetRect();
        Vector2 GetPos();
        Vector2 GetScale();
        float GetRotation();

        //* Setters *//
        void SetPos(Vector2 move);
        void SetScale(Vector2Int set);
        void SetRotation(float rotation);

        //* Miscellaneous Implementations for use *//
        virtual void Render(SDL_Renderer* r);
    protected:
        Rectangle m_renderPosition;
        float m_rotation;    
};

#endif