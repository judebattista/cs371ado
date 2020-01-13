create table roles(
	id 				INT NOT NULL AUTO_INCREMENT,
	role 			VARCHAR(100) NOT NULL,
	pilotQualified 	BOOLEAN NOT NULL,
	PRIMARY KEY ( id )
);

create table crew(
	id 		INT NOT NULL AUTO_INCREMENT,
	fname 	VARCHAR(20),
	lname 	VARCHAR(20),
	age		int,
	roleid int,
	PRIMARY KEY ( id ),
	FOREIGN KEY (roleid)
		REFERENCES roles(id)
		ON UPDATE CASCADE
		ON DELETE SET NULL

);

create table ships (
	id 				INT NOT NULL AUTO_INCREMENT,
	name			VARCHAR(20),
	registration	VARCHAR(20),
);

create table roster (
	id		INT NOT NULL AUTO_INCREMENT,
	crewid	INT NOT NULL,
	shipid	INT NOT NULL,
	PRIMARY KEY (id),
	FOREIGN KEY (crewid)
		REFERENCES crew(id)
		ON UPDATE CASCADE
		ON DELETE CASCADE,
	FOREIGN KEY (shipid)
		REFERENCES ships(id)
		ON UPDATE CASCADE
		ON DELETE CASCADE
);