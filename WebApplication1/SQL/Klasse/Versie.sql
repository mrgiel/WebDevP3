DROP TABLE IF EXISTS Versie;

CREATE TABLE Versie
(
    Versie_id INT NOT NULL PRIMARY KEY  AUTO_INCREMENT,
    afbeelding_url varchar(100),
    isbn VARCHAR(50) UNIQUE ,
    datum DATE,
    druk INT NOT NULL,
    prijs decimal(6,2),
    uitgever_id INT NOT NULL,
    uitgave_id INT NOT NULL,
    FOREIGN KEY (uitgever_id) REFERENCES Uitgever (uitgever_id),
    FOREIGN KEY (uitgave_id) REFERENCES Uitgave (uitgave_id)
);
INSERT INTO Versie (isbn,afbeelding_url, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://5.imimg.com/data5/SELLER/Default/2021/4/EM/TQ/ZH/118480258/red-rose-flower-500x500.jpeg','345345','1995-2-4',1,7,5,6);
INSERT INTO Versie (isbn,afbeelding_url, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR3TulvKSjOUa9X94z49KkElcm9K4VBPVZfeg&usqp=CAU','6456456','1993-2-4',1,2,8,3);
INSERT INTO Versie (isbn,afbeelding_url, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://floweraura-blog-img.s3.ap-south-1.amazonaws.com/flower-gifts-blog/water-lily-most-beautiful-flowers-in-the-world.jpg','45645645','991-4-23',1,0,8,1);
INSERT INTO Versie (isbn,afbeelding_url, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://cdn.shopify.com/s/files/1/0616/0836/2221/files/logo_foto_XXL1_800x.jpg?v=1644575681','34565465','1999-7-24',1,3,3,7);
INSERT INTO Versie (isbn,afbeelding_url, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://5.imimg.com/data5/SELLER/Default/2021/4/EM/TQ/ZH/118480258/red-rose-flower-500x500.jpeg','234234','1993-5-9',1,8,8,2);
INSERT INTO Versie (isbn,afbeelding_url, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://5.imimg.com/data5/SELLER/Default/2021/4/EM/TQ/ZH/118480258/red-rose-flower-500x500.jpeg','64565456','196-3-19',1,2,7,2);
INSERT INTO Versie (isbn,afbeelding_url, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR3TulvKSjOUa9X94z49KkElcm9K4VBPVZfeg&usqp=CAU','6786878','290-4-16',1,1,3,2);
INSERT INTO Versie (isbn,afbeelding_url, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://cdn.shopify.com/s/files/1/0616/0836/2221/files/logo_foto_XXL1_800x.jpg?v=1644575681','64564567','1190-6-13',1,0,7,2);
INSERT INTO Versie (isbn,afbeelding_url, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://cdn.shopify.com/s/files/1/0616/0836/2221/files/logo_foto_XXL1_800x.jpg?v=1644575681','567','2004-4-4',1,.89,8,1);
INSERT INTO Versie (isbn,afbeelding_url, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR3TulvKSjOUa9X94z49KkElcm9K4VBPVZfeg&usqp=CAU','123123','1999-2-20',1,6,7,2);