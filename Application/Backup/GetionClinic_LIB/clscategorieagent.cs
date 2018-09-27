using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clscategorieagent 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clscategorieagent> listes(){
 return clsMetier.GetInstance().getAllClscategorieagent();
}
 public  List<clscategorieagent>   listes(string criteria){
 return clsMetier.GetInstance().getAllClscategorieagent(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClscategorieagent(this);
 }
 public  int  update(clscategorieagent varscls){
 return clsMetier.GetInstance().updateClscategorieagent(varscls);
 }
 public  int  delete(clscategorieagent varscls){
 return clsMetier.GetInstance().deleteClscategorieagent(varscls);
 }
  //***Le constructeur par defaut***
  public    clscategorieagent() 
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
