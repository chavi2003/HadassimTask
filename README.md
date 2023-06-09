# מערכת ניהול קורונה

זהו פרויקט ASP.NET Core Web API המספק מערכת ניהול קורונה לקופת חולים. המערכת מאפשרת למשתמשים להציג וליצור נתונים הקשורים לחברי קופת החולים  באופן כללי וכן נתונים על הקורונה, כגון מידע על מטופל, תוצאות בדיקות ורישומי חיסונים.

## מתחילים

כדי להפעיל את הפרויקט באופן מקומי, יהיה עליך להתקין את Visual Studio 2019, כמו גם את SQL Server Management Studio. בצע את השלבים הבאים כדי להתחיל:

1. טענו את המאגר למחשב המקומי שלכם.
2. פתחו את קובץ הפתרון ב-Visual Studio 2019.
3. שחזרו את חבילות NuGet על ידי לחיצה ימנית על הפתרון בסייר הפתרונות ובחירה ב"שחזר חבילות NuGet".
4. צרו מסד נתונים חדש ב-SQL Server Management Studio, והפעילו את סקריפט ה-SQL שנמצא בתיקייה "Database" כדי ליצור את הטבלאות והנתונים הדרושים.
5. עדכנו את מחרוזת החיבור בקובץ "appsettings.json" כך שתצביע על מופע ה-SQL Server המקומי שלך.
6. בנו והפעילו את הפרויקט.

## שימוש

הפרויקט מספק מספר נקודות קצה של API לניהול נתונים הקשורים לקופת החולים ולקורונה. הנה כמה דוגמאות לשימוש ב-API:

- כדי לאחזר רשימה של כל חברי הקופה, שלח בקשת GET לנקודת הקצה api/Member/GetAllMembers ב swagger
- כדי לאחזר חבר ספציפי לפי תעודת זהות, שלח בקשת GET לנקודת הקצה api/Member/GetMemberById/{id} ב swagger, במקום {id} - ת"ז החבר.
- כדי ליצור חבר חדש, שלח בקשת POST לנקודת הקצה api/Member/AddNewMember, ב swagger, עם נתוני החבר בגוף הבקשה.
- כדי לאחזר רשימה על פרטי הקורונה של כל חברי הקופה, שלח בקשת GET לנקודת הקצה api/Covid/GetAllMembersCovidDetails, ב swagger.  
- כדי לאחזר פרטי קורונה של חבר ספציפי לפי ת"ז, שלח בקשת GET לנקודת הקצה api/Covid/GetMemberById/{id},  ב swagger, במקום {id} - ת"ז החבר.
- כדי להכניס פרטי קורונה לחבר קיים בקופה, שלח בקשת POST לנקודת הקצה api/Covid/AddCovidDetails, ב swagger, עם פרטי הקורונה של החבר.

