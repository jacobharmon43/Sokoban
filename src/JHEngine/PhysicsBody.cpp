#include "PhysicsBody.h"

PhysicsBody::PhysicsBody(){}
PhysicsBody::PhysicsBody(SDL_Texture* t, Rectangle renderPosition, SDL_Color renderColor, int renderOrder, Vector2 velocity, double mass, float rotation){
    m_renderPosition = renderPosition;
    m_renderColor = renderColor;
    m_renderOrder = renderOrder;
    m_velocity = velocity;
    m_rotation = rotation;
    m_mass = mass;
}
PhysicsBody::PhysicsBody(Dynamic d, double mass) : Dynamic(d), m_mass(mass) {}
PhysicsBody::~PhysicsBody(){}

void PhysicsBody::AddForce(Vector2 force)
{
    m_velocity += force / m_mass;
}