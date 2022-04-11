// Jacob Harmon
// Class derived from Object that adds velocity capabilities for easier movement

#ifndef DYNAMIC_H
#define DYNAMIC_H

#include <cmath>
#include "Object.h"
#include "Vector2Int.h"
#include "Vector2.h"

class Dynamic : public Object{
    public:
        //* Constructors *//
        Dynamic();
        Dynamic(SDL_Texture* t, Rectangle renderPosition, SDL_Color renderColor, int renderOrder, Vector2 velocity, float rotation = 0);
        ~Dynamic();

        //* Getters *//
        Vector2 GetVelocity();
        
        //* Setters *//
        void SetVelocity(Vector2 set);
        
        //* Miscellaneous Implementations for use *//
        void Update(float deltaTime);
        bool CheckCollision(Object collidable);
    protected:
        Vector2 m_velocity;
};


#endif