using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsterritoirecommune 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clsterritoirecommune> listes(){
 return clsMetier.GetInstance().getAllClsterritoirecommune();
}
 public  List<clsterritoirecommune>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsterritoirecommune(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsterritoirecommune(this);
 }
 public  int  update(clsterritoirecommune varscls){
 return clsMetier.GetInstance().updateClsterritoirecommune(varscls);
 }
 public  int  delete(clsterritoirecommune varscls){
 return clsMetier.GetInstance().deleteClsterritoirecommune(varscls);
 }
  //***Le constructeur par defaut***
  public    clsterritoirecommune() 
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
