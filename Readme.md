# Faghelg Q3 2011

## Forutsetninger
+ Visual Studio 2010 SP1
+ ASP.NET MVC 3
+ NuGet

## Oppskrift

- Hent prosjekt denne kildekoden fra github.Bruk enten download link oppe til høyre, eller klone med git.
- Kompiler og start prosjektet. Se på hvordan oppdatering av artister er gjort.
- Hent StructureMap.MVC3 fra NuGet
- Ta inn DataStore fra constructoren.
- Lag et action filter for å logge til Debug.WriteLine med hvilke actions som kalles.
- Ta utgangspunkt i Artist og lag tilsvarende for Album.
- Legg på DataAnnotations på view modellen for å validere at kun gyldige album kan lagres i viewet.
- Lag et testprosjekt.
- Test at rikitg data kommer ut av album-modellen.
- Test at man får lagret ny data.
- Add tracks ved å lage en Add-side og med full Postback.
- Vis tracks på album.
- Hent ut album som JSON og legg det i view. Populer en ViewModel i Knockout fra JSONen.
- Render ViewModelen med JQuery Template
- Vis total spilletid på albumet, ved å summere tiden fra tracks.
- Legg til en boks nederst under hvert album, der man kan legge til tracks. Lagre med AJAX til serveren.
- Test view modellen din med QUnit (eller Jasmine).
- Hent album asyncront med AJAX ved henting av side.
- Lag et action filter for rollestyring.
- Legg rolleinfo i ViewBag fra ActionFilter og vis på skjermen.
- Drikk en øl.