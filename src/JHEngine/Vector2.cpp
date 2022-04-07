#include "Vector2.h"

/////////////////////////////////////////////////////
//////////////* Constructors *//////////////////////
////////////////////////////////////////////////////

Vector2::Vector2() : x(0), y(0) {}

Vector2::Vector2(float X, float Y) : x(X), y(Y){}

Vector2::Vector2(const Vector2 &b) : x(b.x), y(b.y){}

Vector2::~Vector2() {}

/////////////////////////////////////////////////////
//////////////* Vector2 operations */////////////
////////////////////////////////////////////////////
bool Vector2::operator ==(Vector2 b){
    return x == b.x && y == b.y;
}

bool Vector2::operator !=(Vector2 b)
{
    return x != b.x || y != b.y;
}

Vector2& Vector2::operator =(Vector2 b){
    x = b.x;
    y = b.y;
    return *this;
}

Vector2 Vector2::operator +(Vector2 b){
    return Vector2(x + b.x, y + b.y);
}

Vector2 Vector2::operator -(Vector2 b){
    return Vector2(x - b.x, y - b.y);
}

Vector2 Vector2::operator *(Vector2 b){
    return Vector2(x * b.x, y * b.y);
}

Vector2 Vector2::operator /(Vector2 b)
{
    return Vector2(x/b.x, y/b.y);
}

Vector2& Vector2::operator +=(Vector2 b){
    x += b.x;
    y += b.y;
    return *this;
}

Vector2& Vector2::operator -=(Vector2 b){
    x -= b.x;
    y -= b.y;
    return *this;
}

Vector2& Vector2::operator *=(Vector2 b){
    x *= b.x;
    y *= b.y;
    return *this;
}

Vector2 Vector2::operator /=(Vector2 b)
{
    x /= b.x;
    y /= b.y;
    return *this;
}

/////////////////////////////////////////////////////
//////////////* Scalar operations */////////////////
////////////////////////////////////////////////////
Vector2 Vector2::operator +(int b){
    return Vector2(x + b, y + b);
}

Vector2 Vector2::operator -(int b){
    return Vector2(x - b, y - b);
}

Vector2 Vector2::operator *(int b){
    return Vector2(x * b, y * b);
}

Vector2 Vector2::operator /(int b)
{
    return Vector2(x / b, y / b);
}

Vector2& Vector2::operator +=(int b){
    x += b;
    y += b;
    return *this;
}

Vector2& Vector2::operator -=(int b){
    x -= b;
    y -= b;
    return *this;
}

Vector2& Vector2::operator *=(int b){
    x *= b;
    y *= b;
    return *this;
}

Vector2& Vector2::operator /=(int b)
{
    x /= b;
    y /= b; 
    return *this;
}

/////////////////////////////////////////////////////
///////////* Miscellaneous functions *//////////////
////////////////////////////////////////////////////

int Vector2::SqrDistance(const Vector2& a, const Vector2& b){
    int xDist = a.x - b.x;
    int yDist = a.y - b.y;
    return xDist*xDist + yDist*yDist;
}

Vector2 Vector2::Reflect(Vector2 line){
    Vector2 dir = Vector2(x,y);
    line = line.Perpendicular().Normalize();
    return dir - line * 2 * (dir.Dot(line))/(line.Dot(line));
}

Vector2 Vector2::Perpendicular()
{
    return Vector2(-y, x);
}

Vector2 Vector2::Normalize()
{
    Vector2 dir = Vector2(x,y);
    float root = sqrt(x*x + y*y);
    return Vector2(dir.x / root, dir.y/root);
}

int Vector2::Dot(Vector2 vector)
{
    return x * vector.x + y * vector.y;
}
