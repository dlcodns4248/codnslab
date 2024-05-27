#include <stdio.h>

int main(void) {
    int i, n = 0, * ptr;
    int sale[2][4] = { {63, 84, 140, 130},
                       {157, 209, 251, 312} }; // 2차원 배열 초기화

    ptr = &sale[0][0]; // Pointer ptr is assigned the address of the first element of sale[0][0]
    for (i = 0; i < 8; i++) { // Loop through 8 elements of the 2D array
        printf("\n address : %u sale %d = %d", ptr, i, *ptr); // Print address and value of current element
        ptr++; // Move the pointer to the next element
    }
    getchar(); // Wait for a character input
    return 0; // Return 0 to indicate successful execution
}
