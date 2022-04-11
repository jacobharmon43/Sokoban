#ifndef VECTOR2_H
#define VECTOR2_H

#include <cmath>
#include <iostream>

class Vector2{
    public:
        double x;
        double y;
        Vector2();
        Vector2(double X, double Y);
        Vector2(const Vector2 &b);
        ~Vector2();
        double SqrDistance(const Vector2& a, const Vector2& b);
        bool operator ==(Vector2 b);
        bool operator !=(Vector2 b);
        Vector2 Reflect(Vector2 line);
        Vector2 Perpendicular();
        Vector2 Normalize();
        double Dot(Vector2 vector);

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
        Vector2& operator =(double b);
        Vector2 operator +(double b);
        Vector2 operator -(double b);
        Vector2 operator *(double b);
        Vector2 operator /(double b);
        Vector2& operator +=(double b);
        Vector2& operator -=(double b);
        Vector2& operator *=(double b);
        Vector2& operator /=(double b);
};

#endif