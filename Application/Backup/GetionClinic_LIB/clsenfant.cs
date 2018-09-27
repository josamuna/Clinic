using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
     public class clsenfant : clspersonne 
{
  //***Les variables globales***
 private int   id ;
 private int   id_maladegrosse ;
 private double?  poid ;
 private double? taille;
 private string   senn ;
 private string   soinsducordo ;
 private bool?  miseausiendansheurquisuitaccouchement ;
 private int?  pc ;
 private string   malformation ;
  //***Listes***
  public new List<clsenfant> listes(){
 return clsMetier.GetInstance().getAllClsenfant();
}
 public  new List<clsenfant>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsenfant(criteria);
 }
 public  new int  inserts(){
 return clsMetier.GetInstance().insertClsenfant(this);
 }
 public  int  update(clsenfant varscls){
 return clsMetier.GetInstance().updateClsenfant(varscls);
 }
 public  int  delete(clsenfant varscls){
 return clsMetier.GetInstance().deleteClsenfant(varscls);
 }
  //***Le constructeur par defaut***
  public    clsenfant() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de id_personne***
 public  int   Id_maladegrosse {

get { return id_maladegrosse; } 
set { id_maladegrosse = value; }
}
  //***Accesseur de poid***
 public  double ?   Poid {

get { return poid; } 
set { poid = value; }
}
  //***Accesseur de taille***
 public  double ?   Taille {

get { return taille; } 
set { taille = value; }
}
  //***Accesseur de senn***
 public  string   Senn {

get { return senn; } 
set { senn = value; }
}
  //***Accesseur de soinsducordo***
 public  string   Soinsducordo {

get { return soinsducordo; } 
set { soinsducordo = value; }
}
  //***Accesseur de miseausiendansheurquisuitaccouchement***
 public  bool ?   Miseausiendansheurquisuitaccouchement {

get { return miseausiendansheurquisuitaccouchement; } 
set { miseausiendansheurquisuitaccouchement = value; }
}
  //***Accesseur de pc***
 public  int ?   Pc {

get { return pc; } 
set { pc = value; }
}
  //***Accesseur de malformation***
 public  string   Malformation {

get { return malformation; } 
set { malformation = value; }
}
} //***fin class

} //***fin namespace
