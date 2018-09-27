using System;
using System.Collections.Generic;

namespace GestionClinic_LIB 
{
  public class   clsattention 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clsattention> listes(){
 return clsMetier.GetInstance().getAllClsattention();
}
 public  List<clsattention>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsattention(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsattention(this);
 }
 public  int  update(clsattention varscls){
 return clsMetier.GetInstance().updateClsattention(varscls);
 }
 public  int  delete(clsattention varscls){
 return clsMetier.GetInstance().deleteClsattention(varscls);
 }
  //***Le constructeur par defaut***
  public    clsattention() 
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

} //***fin class

} //***fin namespace
