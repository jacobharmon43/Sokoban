#ifndef VECTOR2_H
#define VECTOR2_H

#include <cmath>
#include <iostream>

class Vector2{
    public:
        float x;
        float y;
        Vector2();
        Vector2(float X, float Y);
        Vector2(const Vector2 &b);
        ~Vector2();
        float SqrDistance(const Vector2& a, const Vector2& b);
        bool operator ==(Vector2 b);
        bool operator !=(Vector2 b);
        Vector2 Reflect(Vector2 line);
        Vector2 Perpendicular();
        Vector2 Normalize();
        float Dot(Vector2 vector);

        //Vector2 operations
        Vector2& operator =(Vector2 b);
        Vector2 operator +(Vector2 b);
        Vector2 operator -(Vector2 b);
        Vector2 operator *(Vector2 b);
        Vector2 operator /(Vector2 b);
        Vector2& operator +=(Vector2 b);
        Vector2& operator -=(Vector2 b);
        Vector2& operator *=(Vector2 b);
        Vector2 operator /=(Vector2 b);

        //Scalar operations
        Vector2& operator =(float b);
        Vector2 operator +(float b);
        Vector2 operator -(float b);
        Vector2 operator *(float b);
        Vector2 operator /(float b);
        Vector2& operator +=(float b);
        Vector2& operator -=(float b);
        Vector2& operator *=(float b);
        Vector2& operator /=(float b);
};

#endif