using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsgroupe 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
 private int?  niveau ;
  //***Listes***
  public List<clsgroupe> listes(){
 return clsMetier.GetInstance().getAllClsgroupe();
}
 public  List<clsgroupe>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsgroupe(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsgroupe(this);
 }
 public  int  update(clsgroupe varscls){
 return clsMetier.GetInstance().updateClsgroupe(varscls);
 }
 public  int  delete(clsgroupe varscls){
 return clsMetier.GetInstance().deleteClsgroupe(varscls);
 }
  //***Le constructeur par defaut***
  public    clsgroupe() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de designation***
 public  string   Designation {

get { return designation; } 
set { designation = value; }
}

//***Accesseur de niveau***
 public  int ?   Niveau {

get { return niveau; } 
set { niveau = value; }
}
} //***fin class

} //***fin namespace
