using System;
using System.Collections;

public class Matrix 
{
float [] values;
int rows;
int coloumns;
public Matrix(int r , int c,float[] v){
    rows = r;
    coloumns = c;
    values = new float[r * c];
    Array.Copy(v,values,rows * coloumns);
}

public override string ToString(){
    string matrixStr="";
    for(int row = 0 ; row < rows ; row++){
        for(int coloumn = 0 ; coloumn < coloumns ; coloumn++){
            matrixStr += values[row * coloumn + coloumn];
        }
    matrixStr += "\n";
    }
    return matrixStr;
}
public static Matrix operator+ (Matrix a,Matrix b){
    if(a.rows != b.rows || a.coloumns != b.coloumns) return null;
    float[] addValues = new float[a.rows * a.coloumns];
    float length = a.rows * a.coloumns;
    for(int i = 0 ; i < length ; i++){
            addValues[i] = a.values[i]  + b.values[i];
    }
    return new Matrix(a.rows,a.coloumns,addValues);
}
}