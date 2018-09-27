using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsetablissementexterne 
{
  //***Les variables globales***
 private int   id ;
 private string   denomination ;
 private string   adresse ;
 private string telephone;

  //***Listes***
  public List<clsetablissementexterne> listes(){
 return clsMetier.GetInstance().getAllClsetablissementexterne();
}
 public  List<clsetablissementexterne>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsetablissementexterne(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsetablissementexterne(this);
 }
 public  int  update(clsetablissementexterne varscls){
 return clsMetier.GetInstance().updateClsetablissementexterne(varscls);
 }
 public  int  delete(clsetablissementexterne varscls){
 return clsMetier.GetInstance().deleteClsetablissementexterne(varscls);
 }
  //***Le constructeur par defaut***
  public    clsetablissementexterne() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de denomination***
 public  string   Denomination {

get { return denomination; } 
set { denomination = value; }
}
  //***Accesseur de adresse***
 public  string   Adresse {

get { return adresse; } 
set { adresse = value; }
}
  //***Accesseur de telephone***
 public  string   Telephone {

get { return telephone; } 
set { telephone = value; }
}
 public override string ToString()
 {
     return this.Denomination;
 }
} //***fin class

} //***fin namespace
