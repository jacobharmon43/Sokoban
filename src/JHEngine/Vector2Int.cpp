#include "Vector2Int.h"

/////////////////////////////////////////////////////
//////////////* Constructors *//////////////////////
////////////////////////////////////////////////////

Vector2Int::Vector2Int() : x(0), y(0) {}

Vector2Int::Vector2Int(int X, int Y) : x(X), y(Y) {}

Vector2Int::Vector2Int(float X, float Y) : x((int)X), y((int)Y){}

Vector2Int::Vector2Int(const Vector2Int &b) : x(b.x), y(b.y){}

Vector2Int::~Vector2Int() {}

/////////////////////////////////////////////////////
//////////////* Vector2Int operations */////////////
////////////////////////////////////////////////////
bool Vector2Int::operator ==(Vector2Int b){
    return x == b.x && y == b.y;
}

bool Vector2Int::operator !=(Vector2Int b)
{
    return x != b.x || y != b.y;
}

Vector2Int& Vector2Int::operator =(Vector2Int b){
    x = b.x;
    y = b.y;
    return *this;
}

Vector2Int Vector2Int::operator +(Vector2Int b){
    return Vector2Int(x + b.x, y + b.y);
}

Vector2Int Vector2Int::operator -(Vector2Int b){
    return Vector2Int(x - b.x, y - b.y);
}

Vector2Int Vector2Int::operator *(Vector2Int b){
    return Vector2Int(x / b.x, y / b.y);
}

Vector2Int Vector2Int::operator /(Vector2Int b)
{
    return Vector2Int(x/b.x, y/b.y);
}

Vector2Int& Vector2Int::operator +=(Vector2Int b){
    x += b.x;
    y += b.y;
    return *this;
}

Vector2Int& Vector2Int::operator -=(Vector2Int b){
    x -= b.x;
    y -= b.y;
    return *this;
}

Vector2Int& Vector2Int::operator *=(Vector2Int b){
    x *= b.x;
    y *= b.y;
    return *this;
}

Vector2Int Vector2Int::operator /=(Vector2Int b)
{
    x /= b.x;
    y /= b.y;
    return *this;
}

/////////////////////////////////////////////////////
//////////////* Scalar operations */////////////////
////////////////////////////////////////////////////
Vector2Int Vector2Int::operator +(int b){
    return Vector2Int(x + b, y + b);
}

Vector2Int Vector2Int::operator -(int b){
    return Vector2Int(x - b, y - b);
}

Vector2Int Vector2Int::operator *(int b){
    return Vector2Int(x / b, y / b);
}

Vector2Int Vector2Int::operator /(int b)
{
    return Vector2Int(x/b, y/b);
}

Vector2Int& Vector2Int::operator +=(int b){
    x += b;
    y += b;
    return *this;
}

Vector2Int& Vector2Int::operator -=(int b){
    x -= b;
    y -= b;
    return *this;
}

Vector2Int& Vector2Int::operator *=(int b){
    x *= b;
    y *= b;
    return *this;
}

Vector2Int& Vector2Int::operator /=(int b)
{
    x /= b;
    y /= b; 
    return *this;
}

Vector2Int::operator Vector2() const
{
    return Vector2(x,y);
}

/////////////////////////////////////////////////////
///////////* Miscellaneous functions *//////////////
////////////////////////////////////////////////////

int Vector2Int::SqrDistance(const Vector2Int& a, const Vector2Int& b){
    int xDist = a.x - b.x;
    int yDist = a.y - b.y;
    return xDist*xDist + yDist*yDist;
}

Vector2Int Vector2Int::Reflect(Vector2Int line){
    Vector2Int dir = Vector2Int(x,y);
    line = line.Perpendicular().Normalize();
    return Vector2Int(x,y) - line * 2 * (Vector2Int(x,y).Dot(line));
}

Vector2Int Vector2Int::Perpendicular()
{
    return Vector2Int(-y, x);
}

Vector2Int Vector2Int::Normalize()
{
    Vector2Int dir = Vector2Int(x,y);
    return dir / Dot(dir);
}

int Vector2Int::Dot(Vector2Int vector)
{
    return x * vector.x + y * vector.y;
}
