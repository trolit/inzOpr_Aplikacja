###########################################################################

# Projekt aplikacji 
## Implementacja projektu na temat firmy zarządzającej imprezami w postaci aplikacji web'owej

###########################################################################

**Autorzy:**
* Paweł Idzikowski (frontend, backend, testowanie aplikacji)
* Dorota Gil (frontend, testowanie aplikacji)
* Damian Gnatkowski (frontend, tłumaczenie i poprawa etykiet, testowanie aplikacji)
* Maciej Kozikowski (frontend, testowanie aplikacji)

**Wykonanie w** ASP.NET MVC4 (VS 2017 Community)

## PRZYDZIAŁ PLIKÓW I ZADAŃ

**Uwaga** Aby znaleźć w uruchomionej apce gdzie jest wasz plik nad którym pracujecie po prostu przeklikujcie i patrzcie kiedy nazwa pliku ukaże się w adresie.

**@Dorota Gil** \
        - [X] zarządzanie ogólnym stylem graficznym aplikacji poprzez plik style.css(a co za tym idzie tło strony, czcionka nagłówka itp.) <br/>
	- [X] opracowanie navbara i stopki <br/>
	- [X] opracowanie poniższych plików *.cshtml  <br/>
	
		  - [X] Create_Zgloszenie.cshtml  
		  - [X] Create_Dokumentacja.cshtml 
		  - [X] Create_Personel.cshtml 
		  - [X] Create_Pozwolenie.cshtml 
		  - [X] Klient_Sukces.cshtml 
		  - [X] Index.cshtml 
		  - [X] Klienci.cshtml   
		  - [X] Pracownik.cshtml  
		  - [X] Pozwolenia.cshtml  
		  - [X] Personel.cshtml 
		  - [X] Uczestnik_imprezy_Sukces.cshtml  
		  - [X] Uczestnik_imprezy_Create.cshtml   
		  - [X] Dokumentacja.cshtml   
		  - [X] Przelozony_Listaimprez.cshtml 
		  - [X] Przelozony.cshtml ~~(nowe)~~
		  
**@Damian Gnatkowski** \
        - [X] spolszczenie aplikacji(dotyczy to wszystkich plików cshtml), wprowadzenie jednolitych nazw. np. przycisk powrotu na każdej stronie ma taką samą nazwę i oprawę graficzną i zrobienie żeby w widokach z formularzami np. edycji Dokumentacji labelami(etykietami)nie były nazwy pól z tabeli a sensowny tekst(czyli zamiast np. nrTel to profesjonalnie: Numer telefonu) <br/>
	- [X] kontrola działania przycisków (powiązanie ich tak aby działały zgodnie z zamierzeniem) <br/>
	- [X] opracowanie plików *.cshtml <br/>
		
		  - [X] Details_Pracownik.cshtml 
		  - [X] Details_Przelozony.cshtml 
		  - [X] DetailsDokumentacja.cshtml  
		  - [X] DetailsPersonel.cshtml 
		  - [X] DetailsPozwolenia.cshtml  
		  - [X] Przelozony_Imprezy_Details.cshtml  
		  - [X] Imprezy_Details.cshtml 
		  - [X] EditUczestnik.cshtml 
		  - [X] EditPersonel.cshtml 
		  - [X] EditPozwolenie.cshtml 
		  - [X] Edit_Przelozony.cshtml 
		  - [X] EditDokumentacja.cshtml 

**@Maciej Kozikowski** \
        - [X] testowanie funkcjonowania aplikacji i zgłaszanie usterek <br/>
	- [X] opracowanie poniższych plików *.cshtml  <br/>
		
		  - [X] Delete_Przelozony.cshtml   
		  - [X] DeleteDokumentacja.cshtml 
		  - [X] DeletePersonel.cshtml 
		  - [X] DeletePozwolenie.cshtml 
		  - [X] DeleteUczestnik.cshtml 
		  - [X] Imprezy_Delete.cshtml 
		  - [X] Imprezy_Dostepne.cshtml 
		  - [X] Imprezy_Edit.cshtml 
		  - [X] -----------------------
		  - [X] Uczestnicy_Lista.cshtml
		  - [X] Uczestnik_imprezy.cshtml 
		  - [X] Zgloszenia_Przelozony.cshtml 


## OGÓLNE ZASADY (JAK OPRACOWAĆ PLIKI)

1. Pull'am.
2. ~~Stosujcie się do **konwencji interfejsu z projektu**.~~
3. We fragmencie, który odpowiada za tytuł strony(nazwa którą widać w zakładce w przeglądarce), umieśćcie sensowny tytuł strony.
4. **Urozmaicajcie interfejs**(np. ikonami, zdjęciami adekwatnymi do pliku) ale bez przesady.
5. Zgodnie z projektem interfejsu **podstawowe elementy, które mają znaleźć się w waszych plikach** to:
c) przycisk powrotu do poprzedniego okna (przycisk powinien być jednolity wszędzie zatem rzucam tu kodem
aby wrzucić przycisk(@Damian): 

<input type="button" value="Wróć" class="btn btn-primary btn-md przyciskPowrot" onclick="window.location='@Url.Action("Nazwa pliku do ktorego przejsc", "Home")'" />

** Szczególnie zwróć tu **@Damian** uwagę aby każdy przycisk który działa jako powrót do poprzedniej strony miał klasę "przyciskPowrot" żeby można było łatwiej tym zarządzać. **

6. **Nie usuwajcie bloku nagłówka z klasą** "naglowekStrony" aby @Dorota mogła zarządzać tym blokiem poprzez style.css
7. Korzystajcie z dobroci Bootstrapa (~~jednak miejcie na uwadze ze mamy tu wersje 3.0.0~~)
8. **Nie zmieniajcie nazw plików żeby nie było konfliktów**.