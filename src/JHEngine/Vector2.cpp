#include "Vector2.h"

/////////////////////////////////////////////////////
//////////////* Constructors *//////////////////////
////////////////////////////////////////////////////

Vector2::Vector2() : x(0), y(0) {}

Vector2::Vector2(double X, double Y) : x(X), y(Y){}

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
Vector2 Vector2::operator +(double b){
    return Vector2(x + b, y + b);
}

Vector2 Vector2::operator -(double b){
    return Vector2(x - b, y - b);
}

Vector2 Vector2::operator *(double b){
    return Vector2(x * b, y * b);
}

Vector2 Vector2::operator /(double b)
{
    return Vector2(x / b, y / b);
}

Vector2& Vector2::operator +=(double b){
    x += b;
    y += b;
    return *this;
}

Vector2& Vector2::operator -=(double b){
    x -= b;
    y -= b;
    return *this;
}

Vector2& Vector2::operator *=(double b){
    x *= b;
    y *= b;
    return *this;
}

Vector2& Vector2::operator /=(double b)
{
    x /= b;
    y /= b; 
    return *this;
}

/////////////////////////////////////////////////////
///////////* Miscellaneous functions *//////////////
////////////////////////////////////////////////////

Vector2 Vector2::Reflect(Vector2 line){
    Vector2 dir = Vector2(x,y);
    line = line.Normalize();
    Vector2 nw = line*(2*(line.Dot(dir)));
    return dir - nw;
}

Vector2 Vector2::Perpendicular()
{
    return Vector2(-y, x);
}

Vector2 Vector2::Normalize()
{
    Vector2 dir = Vector2(x,y);
    return dir/sqrt(x*x + y*y);
}

double Vector2::Dot(Vector2 vector)
{
    return x * vector.x + y * vector.y;
}
