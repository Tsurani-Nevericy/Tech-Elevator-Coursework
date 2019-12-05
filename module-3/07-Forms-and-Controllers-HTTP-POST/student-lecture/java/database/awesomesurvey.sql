DROP TABLE IF EXISTS survey;

CREATE TABLE survey (
        id serial primary key,
        favoriteColor varchar(32),
        natureOfQuest varchar(255),
        petPreference varchar(32),
        emailAddress varchar(255),
        languagePreference varchar(16)
);
