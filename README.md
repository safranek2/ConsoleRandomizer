# Náhodný Generátor v Konzoli

Tento projekt je jednoduchá konzolová aplikace implementující různé generátory náhodných dat. Uživatel má možnost vybírat z různých funkcí, jako je generování náhodných abeced, zemí, čísel, hesel, a mnoho dalšího. Projekt je napsán v jazyce C# a běží v konzoli.

## Funkce
### Generátory
1. **Země**: Generuje náhodnou zemi.
2. **Kostky**: Generuje hod kostkami podle nastavení kostek.
3. **Magic8Ball**: Simuluje odpovědi kouzelné koule osudu.
4. **Čísla**: Generuje náhodná čísla podle zadaných parametrů.
5. **Hesla**: Generuje náhodné hesla podle zadaných pravidel.
6. **Týmy**: Generuje náhodné týmy pro soutěže a hry.
7. **Ano nebo Ne**: Generuje náhodnou odpověď ano nebo ne.
8. **Hody mincí**: Simuluje hod mincí.
9. **Kámen, nůžky, papír**: Simuluje hru kámen, nůžky, papír.
10. **Barvy**: Generuje náhodnou barvu a zobrazí nejbližší barvu vygenerované barvy.
11. **Písmena**: Generuje náhodné písmeno z různých abeced.
12. **Seznam**: Generuje náhodný název se seznamu nebo ho zamíchá.
13. **Karty**: Generuje náhodnou kartu.
14. **Datum**: Generuje náhodné datum.
15. **Čas**: Generuje náhodný čas.

### Nastavení
Pro každý generátor jsou k dispozici soubory JSON s nastavením, které mohou být upraveny podle potřeb uživatele. Tyto soubory se nachází ve složce `Resources` ve formátu `NazevGeneratoru.json`.

## Použití
### Pro Developera:
1. Stáhněte zdrojový kód z tohoto repozitáře.
2. Otevřete projekt ve svém oblíbeném vývojovém prostředí, které podporuje .NET 7.
3. Pro spuštění aplikace použijte sestavení projektu.

### Pro Uživatele:
1. Stáhněte a rozbalte archiv s kompilovanou aplikací.
2. Spusťte aplikaci pomocí spustitelného souboru `ConsoleRandomizer.exe`, který se nachází ve složce `ConsoleRandomizer\bin\Release`.
3. Po spuštění zobrazí aplikace hlavní menu, kde si můžete vybrat požadovanou funkci.

## Další Informace
- Projekt využívá jazyk C# a běží v .NET 7 prostředí.
- Pro načítání dat z JSON souborů je použita knihovna Newtonsoft.Json.
- Kód je dobře komentován a strukturován pro snadnou čitelnost a úpravy.
- JSON soubory se nachází ve složce `Resources`.

## Licence
Tento projekt je licencován pod [MIT licencí](LICENSE.txt).
