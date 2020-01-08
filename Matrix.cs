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
    values = new float[rows * coloumns];
    // copy the values from the source to destination
    Array.Copy(v,values,rows * coloumns);
}

public Coords AsCords(){
    if(rows == 4 || coloumns == 4){
        Coords temp = new Coords(values[0],values[1],values[2],values[3]);
        return temp;
    }else {
        return null;
    }
}

public override string ToString(){
    string matrixStr="";
    for(int r = 0 ; r < rows ; r++){
        for(int c = 0 ; c < coloumns ; c++){
            matrixStr += values[r * coloumns + c] + " ";
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

    public static Matrix operator* (Matrix a,Matrix b){
    if(a.coloumns != b.rows) return null;
    float[] val = new float[a.rows * b.coloumns];
        for(int i = 0 ; i < a.rows ; i++){
            for(int j = 0 ; j < b.coloumns ; j++){
                for(int k = 0 ; k < a.coloumns ; k++){
                    val[i * b.coloumns + j] += a.values[i * a.coloumns + k] + b.values[k * b.coloumns +j];
                }
            }
        }
        Matrix temp = new Matrix(a.rows,b.coloumns,val);
        return temp;
    }
}