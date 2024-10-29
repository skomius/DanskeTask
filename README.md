# AxiomaTask

## Naudojimas

Importuoti failą ir tada atlikti paiešką. Komandų seka:
1. import -r Path 
2. search -q "Property='value'"

Example: search -q "msg='Security*' And suser='KKsenja'" 

## Savybės
Programa palaiko daugiau negu vieno failo importą, apsaugą nuo dublikatų, pranešimus pagal log severity, rodo rezultato įrašų skaičių, boolean duomenų tipo palaikymas, 
filtruoja pagal dalį įrašo ('*value*'), įrašo pradžią ('value*'), pabaigą('*value'), rezultatų pateikimą JSON formatu, persistence layeris paieškos rezultatams saugoti.
