using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsattention_speciale 
{
  //***Les variables globales***
 private int   id ;
 private int?  id_malade ;
 private int?  id_attention ;
 private bool?  dort_sous_moust ;
  //***Listes***
  public List<clsattention_speciale> listes(){
 return clsMetier.GetInstance().getAllClsattention_speciale();
}
 public  List<clsattention_speciale>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsattention_speciale(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsattention_speciale(this);
 }
 public  int  update(clsattention_speciale varscls){
 return clsMetier.GetInstance().updateClsattention_speciale(varscls);
 }
 public  int  delete(clsattention_speciale varscls){
 return clsMetier.GetInstance().deleteClsattention_speciale(varscls);
 }
  //***Le constructeur par defaut***
  public    clsattention_speciale() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de id_malade***
 public  int ?   Id_malade {

get { return id_malade; } 
set { id_malade = value; }
}
  //***Accesseur de id_attention***
 public  int ?   Id_attention {

get { return id_attention; } 
set { id_attention = value; }
}
  //***Accesseur de dort_sous_moust***
 public  bool ?   Dort_sous_moust {

get { return dort_sous_moust; } 
set { dort_sous_moust = value; }
}

} //***fin class

} //***fin namespace
