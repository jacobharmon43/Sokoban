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
        Object();
        Object(SDL_Texture* t, Rectangle renderPosition, SDL_Color renderColor, int renderOrder, float rotation = 0);
        ~Object();
        
        //* Getters *//
        Rectangle GetRect();
        Vector2 GetPos();
        Vector2Int GetScale();
        float GetRotation();

        //* Setters *//
        void SetPos(Vector2 move);
        void SetScale(Vector2Int set);
        void SetRotation(float rotation);

        virtual void Render(SDL_Renderer* r);
    protected:
        Rectangle m_renderPosition;
        SDL_Color m_renderColor;
        int m_renderOrder;
        float m_rotation;
        SDL_Texture* m_texture;
        
};

#endif