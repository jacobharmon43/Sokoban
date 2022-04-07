#ifndef DYNAMIC_H
#define DYNAMIC_H

#include <cmath>
#include "Object.h"
#include "Vector2Int.h"
#include "Vector2.h"

class Dynamic : public Object{
    public:
        Dynamic();
        Dynamic(Rectangle renderPosition, SDL_Color renderColor, int renderOrder, Vector2 velocity);
        ~Dynamic();
        void Render(SDL_Renderer* r);
        void ChangeVelocity(Vector2 change);
        void SetVelocity(Vector2 set);
        Vector2 GetVelocity();
        void Update();
        bool CheckCollision(Object collidable);
    protected:
        Vector2 m_velocity;
};

#endif