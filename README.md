###########################################################################

# Projekt aplikacji 
## Implementacja projektu na temat firmy zarządzającej imprezami w postaci aplikacji web'owej

###########################################################################

Autorzy:
* Paweł Idzikowski (backend)
* Dorota Gil (frontend)
* Damian Gnatkowski (frontend, tłumaczenie)
* Maciej Kozikowski (frontend, testowanie)

** Wykonanie w ** ASP.NET MVC4 (VS 2017 Community)

## PRZYDZIAŁ PLIKÓW I ZADAŃ

**Uwaga** Aby znaleźć w uruchomionej apce gdzie jest wasz plik nad którym pracujecie po prostu przeklikujcie i patrzcie kiedy nazwa pliku ukaże się w adresie.

@Dorota Gil \
        - [ ] zarządzanie ogólnym stylem graficznym aplikacji poprzez plik style.css(a co za tym idzie tło strony, czcionka nagłówka itp.) \
		- [ ] opracowanie navbara i stopki \
		- [ ] opracowanie plików *.cshtml  \
		  - [ ] Create_Zgloszenie.cshtml  \
		  - [ ] Create_Dokumentacja.cshtml \
		  - [ ] Create_Personel.cshtml \
		  - [ ] Create_Pozwolenie.cshtml \
		  - [ ] Klient_Sukces.cshtml \
		  - [ ] Index.cshtml \
		  - [ ] Klienci.cshtml \
		  - [ ] Pracownik.cshtml \
		  - [ ] Pozwolenia.cshtml \
		  - [ ] Personel.cshtml \
		  - [ ] Uczestnik_imprezy_Sukces.cshtml \
		  - [ ] Uczestnik_imprezy_Create.cshtml \
		  - [ ] Dokumentacja.cshtml \
		  - [ ] Przelozony_Listaimprez.cshtml \
		  
@Damian Gnatkowski \
        - [ ] spolszczenie aplikacji i wprowadzenie jednolitych nazw. np. przycisk powrotu na każdej stronie ma taką samą nazwę i oprawę graficzną \
		- [ ] kontrola działania przycisków (powiązanie ich tak aby działały zgodnie z zamierzeniem) \
		- [ ] opracowanie plików *.cshtml \ 
		  - [ ] Details_Pracownik.cshtml \
		  - [ ] Details_Przelozony.cshtml \
		  - [ ] DetailsDokumentacja.cshtml \ 
		  - [ ] DetailsPersonel.cshtml \ 
		  - [ ] DetailsPozwolenia.cshtml \ 
		  - [ ] Przelozony_Imprezy_Details.cshtml \ 
		  - [ ] Imprezy_Details.cshtml \ 
		  - [ ] EditUczestnik.cshtml \
		  - [ ] EditPersonel.cshtml \
		  - [ ] EditPozwolenie.cshtml \
		  - [ ] Edit_Przelozony.cshtml \
		  - [ ] EditDokumentacja.cshtml \

@Maciej Kozikowski \
        - [ ] testowanie funkcjonowania aplikacji i zgłaszanie usterek \
		- [ ] opracowanie plików *.cshtml  \
		  - [ ] Delete_Przelozony.cshtml \
		  - [ ] DeleteDokumentacja.cshtml \
		  - [ ] DeletePersonel.cshtml \
		  - [ ] DeletePozwolenie.cshtml \
		  - [ ] DeleteUczestnik.cshtml \
		  - [ ] Imprezy_Delete.cshtml \
		  - [ ] Imprezy_Dostepne.cshtml \
		  - [ ] Imprezy_Edit.cshtml \
		  - [ ] Przelozony.cshtml \
		  - [ ] Uczestnicy_Lista.cshtml \
		  - [ ] Uczestnik_imprezy.cshtml \
		  - [ ] Zgloszenia_Przelozony.cshtml \


## OGÓLNE ZASADY (JAK OPRACOWAĆ PLIKI)

1. Przed zaczęciem pracy nad projektem róbcie "Pull" repozytorium bo może ktoś już coś zedytował (żebyście pracowali na najnowszej wersji). Jeżeli korzystacie z aplikacji to jak wejdziecie na repozytorium to kliknijcie "Refresh_repository" zeby zobaczyc czy nie ma nowych wstawek.
2. Stosujcie się do konwencji interfejsu, który wykonaliśmy w dokumentacji aby było jednolicie u każdego.
3. We fragmencie, który odpowiada za tytuł strony(nazwa którą widać w zakładce w przeglądarce), umieśćcie sensowny tytuł strony.
4. Urozmaicajcie interfejs(np. ikonami, zdjęciami adekwatnymi do pliku, który ogarniacie).
5. Zgodnie z projektem interfejsu podstawowe elementy, które mają znaleźć się w waszych plikach to:
a) nagłówek strony
b) treść strony
c) przycisk powrotu do poprzedniego okna (przycisk powinien być jednolity wszędzie zatem rzucam tu kodem
aby wrzucić przycisk(@Damian): 

<input type="button" value="Wróć" class="btn btn-primary btn-md przyciskPowrot" onclick="window.location='@Url.Action("Nazwa pliku do ktorego przejsc", "Home")'" />

** Szczególnie zwróć tu @Damian uwagę aby każdy przycisk który działa jako powrót do poprzedniej strony miał klasę "przyciskPowrot" żeby można było łatwiej tym zarządzać. **

Tu fotka jak ma wyglądać układ waszych stron
![Error](https://github.com/trolit/inzOpr_Aplikacja/blob/master/images/example.PNG)

6. **Nie usuwajcie bloku nagłówka z klasą** "naglowekStrony" aby @Dorota mogła zarządzać tym blokiem poprzez style.css
7. Korzystajcie z dobroci Bootstrapa (jednak miejcie na uwadze ze mamy tu wersje 3.0.0)
8. Nie zmieniajcie nazw plików żeby nie było konfliktów.
9. Nie modyfikujcie elementów za które nie jesteście odpowiedzialni żeby nie robić konfliktów :)
10. Najlepiej testujcie swoje zmiany w przeglądarce "Chrome" żeby nie było potem niespodzianek że np. w Firefox nagłówek jest dziwny :PLIKI


## Sugestie 

**Uwaga** Jeżeli macie np. formularz to warto pomyśleć o dodaniu w inputach "value" 
(tu podpowiedź: [KLIKNIJ MNIE](https://stackoverflow.com/questions/6062528/html-editorfor-set-default-value) ) 

**Uwaga** Jeżeli macie formularz to warto pomyśleć o sugestiach przy polach w formie ikonek znaków zapytania  - możemy je zrobić za pomocą tzw. tooltip w bootstrapie
(tu zobaczycie jak to wygląda: [KLIKNIJ MNIE](https://www.w3schools.com/bootstrap/bootstrap_tooltip.asp) ) 

**Uwaga** Może formularz dać wewnątrz karty? :) (link: [KLIKNIJ MNIE](https://getbootstrap.com/docs/4.0/components/card/) ) 