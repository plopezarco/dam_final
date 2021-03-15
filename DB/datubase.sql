CREATE DATABASE genshin;

use genshin;

CREATE TABLE characters (
    id INT NOT NULL AUTO_INCREMENT,
    name_character VARCHAR (50) NOT NULL,
    weapon VARCHAR (50) NOT NULL,
    element VARCHAR (50) NOT NULL,
    rarity INT NOT NULL,
    birthday VARCHAR (50) NOT NULL,
    seiyuu VARCHAR (50) NOT NULL,
    region VARCHAR(50) NOT NULL,
    description_character VARCHAR (500) NOT NULL,
    PRIMARY KEY (id)
);

INSERT INTO characters (name_character, weapon, element, rarity, birthday, seiyuu, region, description_character) VALUES
    ('Amber', 'Bow', 'Fire', 4, '08-10', 'Manaka Iwami', 'Mondstadt', 'A perky, straightforward girl, who is also the only Outrider of the Knights of Favonius.'),
    ('Jean', 'Sword', 'Anemo', 5, '03-14', 'Saito Chiwa', 'Mondstadt', ' As the Acting Grand Master of the Knights, Jean has always been devoted to her duties and maintaining peace in Mondstadt.'),
    ('Lisa', 'Catalyst', 'Electro', 4, 'June 9th', 'Rie Tanaka', 'Mondstadt', 'She is an intellectual witch who can never get enough naps. As the Librarian of the Knights of Favonius, Lisa is smart in that she always knows exactly what to do with whatever troubles her.'),
    ('Kaeya', 'Sword', 'Cryo', 4, 'November 30th', 'Toriumi Kohsuke', 'Mondstadt', 'In the Knights of Favonius, Kaeya is the most trusted aide for the Acting Grand Master Jean. You can always count on him to solve any intractable problems.'),
    ('Barbara', 'Catalyst', 'Hydro', 4, 'July 5th', 'Kito Akari', 'Mondstadt', 'The Deaconess of the Favonius Church and a shining starlet adored by all.'),
    ('Diluc', 'Claymore', 'Fire', 5, 'April 30th', 'Ono Kenshou', 'Mondstadt', 'As the wealthiest gentleman in Mondstadt, the ever-dapper Diluc always presents himself as the epitome of perfection.'),
    ('Razor', 'Claymore', 'Electro', 4, '​September 9th', 'Uchiyama Kouki', 'Mondstadt', 'Some say he is an orphan raised by wolves. Others say he is a wolf spirit in human form.'),
    ('Venti', 'Bow', 'Anemo', 5, 'June 16th', 'Murase Ayumu', 'Mondstadt', 'A bard that seems to have arrived on some unknown wind — sometimes sing songs as old as the hills, and other times sing poems fresh and new.'),
    ('Klee', 'Catalyst', 'Fire', 5, 'July 27th', 'Kuno Misaki', 'Mondstadt', 'Knights of Favonius Spark Knight! Forever with a bang and a flash! —And then disappearing from the stern gaze of Acting Grand Master Jean.'),
    ('Bennett', 'Sword', 'Fire', 4, '​February 29th', 'Ousaka Ryouta', 'Mondstadt', 'The few young adventurers that the Mondstadt Adventurers Guild has always find themselves tangled up in baffling bouts of bad luck.'),
    ('Noelle', 'Claymore', 'Geo', 4, '​March 21st', 'Takao Kanon', 'Mondstadt', 'Like most of Mondstadt s young people, Noelle always dreamed of being a knight of Favonius when she grew up.'),
    ('Fischl', 'Bow', 'Electro', 4, '​May 27th', 'Uchida Maaya', 'Mondstadt', 'A mysterious girl who calls herself "Prinzessin der Verurteilung" and travels with a night raven named Oz.'),
    ('Sucrose', 'Catalyst', 'Anemo', 4, 'November 26th', 'Fujita Akane', 'Mondstadt', 'An alchemist with an insatiable curiosity towards the world and everything in it. Attached to the Knights of Favonius as an assistant to Albedo, her area of focus is "bio-alchemy."'),
    ('Mona', 'Catalyst', 'Hydro', 5, '​August 31st', 'Kohara Konomi', 'Mondstadt', 'A mysterious young astrologer who proclaims herself to be "Astrologist Mona Megistus," and who possesses abilities to match the title. Erudite, but prideful.'),
    ('Diona', 'Bow', 'Cryo', 4, '​January 18th', 'Izawa Shiori', 'Mondstadt', 'The incredibly popular bartender of the Cat s Tail tavern, rising star of Mondstadt s wine industry, and the greatest challenger to its traditional powerhouses.'),
    ('Albedo', 'Sword', 'Geo', 5, 'September 13th', 'Nojima Kenji', 'Mondstadt', 'Albedo — an alchemist based in Mondstadt, in the service of the Knights of Favonius.'),
    ('Xiao', 'Polearm', 'Anemo', 5, '​April 17th', 'Matsuoka Yoshitsugu', 'Liyue', 'One of the mighty and illuminated adepti guarding Liyue, also heralded as the "Vigilant Yaksha."'),
    ('Beidou', 'Claymore', 'Electro', 4, '​February 14th', 'Koshimizu Ami', 'Liyue', 'Captain of the Crux, with quite the reputation in Liyue.'),
    ('Ninguang', 'Catalyst', 'Geo', 4, '​August 26th', 'Ohara Sayaka', 'Owner of the Jade Chamber in the skies above Liyue, there are stories abound about Ningguang, with her elegance and mysterious smile.'),
    ('Xiangling', 'Polearm', 'Fire', 4, 'November 2nd', 'Ozawa Ari', 'Liyue', 'The Head Chef at the Wanmin Restaurant and also a waitress there, Xiangling is extremely passionate about cooking and excels at her signature hot and spicy dishes.'),
    ('Xingqiu', 'Sword', 'Hydro', 4, 'October 9th', 'Minagawa Junko', 'Liyue', 'Second son of the Feiyun Commerce Guild, Xingqiu has had a reputation for being studious and polite ever since he was a young child.'),
    ('Chongyun', 'Claymore', 'Cryo', 4, '​September 7th', 'Saito Soma', 'Liyue', 'An exorcist who roams the land with Liyue as his base of operations, evil spirits fleeing wherever he goes. As the heir to a clan of exorcists, he has always possessed abilities superior to most. However, these abilities are not the result of training, but of an inborn trait — a pure-yang spirit.'),
    ('Qiqi', 'Sword', 'Cryo', 5, '​March 3rd', 'Tamura Yukari', 'Liyue', 'An apprentice and herb gatherer at Bubu Pharmacy. "Blessed" by the adepti with a body that cannot die, this petite zombie cannot do anything without first giving herself orders to do it.'),
    ('Keqing', 'Sword', 'Electro', 5, '​November 20th', 'Kitamura Eri', 'Liyue', 'The Yuheng of the Liyue Qixing. Keqing has much to say about Rex Lapis unilateral approach to policymaking in Liyue ⁠— but in truth, gods admire skeptics such as her quite a lot.'),
    ('Childe', 'Bow', 'Hydro', 5, '​July 20th', 'Kimura Ryohei', 'Liyue', 'Meet Childe — the cunning Snezhnayan whose unpredictable personality keeps people guessing his every move.'),
    ('Zhongli', 'Polearm', 'Geo', 5, '​​December 31st', 'Maeno Tomoaki', 'Liyue', 'Wangsheng Funeral Parlor mysterious consultant. Handsome, elegant, and surpassingly learned.'),
    ('Xinyan', 'Claymore', 'Fire', 4, 'October 16th', 'Takahashi Chiaki', 'Liyue', 'Rock and roll is an avant-garde art in Liyue Harbor and Xinyan is the pioneer in this field.'),
    ('Ganyu', 'Bow', 'Cryo', 5, '​​December 2nd', 'Ueda Reina', 'Liyue', 'The secretary to the Liyue Qixing. The blood of both human and illuminated beast flows within her veins.');