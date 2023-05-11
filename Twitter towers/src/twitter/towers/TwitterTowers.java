
package twitter.towers;

import java.util.Scanner;


public class TwitterTowers {

    public static void printScope(int choice,int height, int width){
        if(choice==1)
            System.out.println(" The scope of the tower is: "+(height*2+width*2));
        else
            System.out.println(" The scope of the tower is: "+(width+height*2));
    }
    public static void printArea(int height, int width){
        System.out.println(" The area of the tower is: "+(height*width));
    }
    public static void checkPrint(int height, int width){
        if(height==width||Math.abs((width-height))>5)
            printArea(height,width);
        else
            printScope(1,height,width);      
    }
    public static void printTriangular(int height, int width){
        
        if(width%2==0||width>(height*2)){
            
            System.out.println(" The triangle is not printable");
            return; }
        int i,j,k;
        if(width==3&&height==3){
            System.out.println(" * ");
            System.out.println("***");
            System.out.println("***");
        }
        else{
        int lines=(height-2)/((width-(width/2))-2);
        int levels=(width-(width/2)-2);
        int asterisks=3;
        int flag=0;
        if(((height-2)%levels)>0){
            flag=1;
        }
          for(i=0; i<width; i++){
              if(i==(int)(width/2)){
                  System.out.print("*");
                  i++;
              }
              System.out.print(" ");
          }
            
            System.out.println("");
            if(flag==1){
                for(i=0; i<((height-2)%levels); i++){
                    for(j=0; j<((width-3)/2); j++)
                        System.out.print(" ");
                    System.out.print("***");
                    for(j=0; j<((width-3)/2); j++)
                        System.out.print(" ");
                    System.out.println("");
                }
            }
        for(i=0; i<levels; i++){
            for(j=0; j<lines; j++){
                for(k=0; k<((width-asterisks)/2); k++)
                    System.out.print(" ");
                for(k=0; k<asterisks; k++)
                    System.out.print("*");
                for(k=0; k<((width-asterisks)/2); k++)
                    System.out.print(" ");
                System.out.println("");
                
            }
            asterisks+=2;
        }
        
        for(i=0; i<width; i++){ 
              System.out.print("*");
          }
        System.out.println(""); 
    }
    }
    public static void main(String[] args) {
        Scanner in=new Scanner(System.in);
        int choice=0;
        int height, width;
        System.out.println(" Hello, wellcome to twitter towers!");
        while(true){   
            do{
                System.out.println(" please press: \n 1 for retangle,\n 2 for triangular, \n 3 to exit.");
                choice=in.nextInt();
            }while(choice!=1&&choice!=2&&choice!=3);
            if(choice==3){
                System.out.println(" goodby");
                break;
            }
        System.out.println(" Please enter the height of your tower");
        height=in.nextInt();
        System.out.println(" Please enter the width of your tower");
        width=in.nextInt();
        if(choice==1){ 
         checkPrint(height,width);   
        }
        else{ 
            System.out.println(" Press 1 to see the scope of the triangular, 0 to skip");
            if(in.nextInt()==1)
                printScope(2,height,width);
            System.out.println(" Press 2 to print the triangular tower or 0 to skip");
            if(in.nextInt()==2){
               printTriangular(height,width); 
            }
        
        }
        
    }
    
}}
