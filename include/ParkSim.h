#ifndef PARKSIM_H
#define PARKSIM_H

#include <iostream>
#include "JHEngine.h"

class ParkSimulator : public Game{
    public:
        ParkSimulator();
        ParkSimulator(int width, int height);
        ~ParkSimulator();

        void Init(const char* name);
        bool Update(double deltaTime);
        void Draw();
        void Close();
    private:
        bool PollKeyboard(const Uint8* input);
};

#endif 