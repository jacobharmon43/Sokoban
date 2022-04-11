#ifndef PHYSICSBODY_H
#define PHYSICSBODY_H

#include "Dynamic.h"

class PhysicsBody : public Dynamic{
    public:
        PhysicsBody();
        PhysicsBody(Dynamic d, double mass = 1);
        PhysicsBody(SDL_Texture* t, Rectangle renderPosition, SDL_Color renderColor, int renderOrder, Vector2 velocity, double mass = 1, float rotation = 0);
        ~PhysicsBody();
        void AddForce(Vector2 force);

        double GetMass();
        void SetMass();
    protected:
        double m_mass;
};

#endif 