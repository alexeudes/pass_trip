﻿using System;
using System.ComponentModel;

namespace pass_trip
{
	public enum LanguagesEnum
	{
        [Description("Arabic")]
        ara = 1,
        [Description("English")]
        eng,
        [Description("Greek")]
        ell,
        [Description("Turkish")]
        tur,
        [Description("Tigrinya")]
        tir,
        [Description("Italian")]
        ita,
        [Description("Latin")]
        lat,
        [Description("Cook Islands Māori")]
        rar,
        [Description("Somali")]
        som,
        [Description("Spanish")]
        spa,
        [Description("Russian")]
        rus,
        [Description("Turkmen")]
        tuk,
        [Description("Albanian")]
        sqi,
        [Description("Croatian")]
        hrv,
        [Description("Portuguese")]
        por,
        [Description("Tetum")]
        tet,
        [Description("French")]
        fra,
        [Description("Kikongo")]
        kon,
        [Description("Lingala")]
        lin,
        [Description("Azerbaijani")]
        aze,
        [Description("Swahili")]
        swa,
        [Description("Samoan")]
        smo,
        [Description("Vietnamese")]
        vie,
        [Description("Dari")]
        prs,
        [Description("Pashto")]
        pus,
        [Description("Latvian")]
        lav,
        [Description("Kyrgyz")]
        kir,
        [Description("Polish")]
        pol,
        [Description("Chamorro")]
        cha,
        [Description("Lithuanian")]
        lit,
        [Description("Armenian")]
        hye,
        [Description("Jèrriais")]
        nrf,
        [Description("Tajik")]
        tgk,
        [Description("Amharic")]
        amh,
        [Description("Berber")]
        ber,
        [Description("Hassaniya")]
        mey,
        [Description("Māori")]
        mri,
        [Description("Malay")]
        msa,
        [Description("Niuean")]
        niu,
        [Description("Romanian")]
        ron,
        [Description("Norwegian")]
        nor,
        [Description("Belarusian")]
        bel,
        [Description("Czech")]
        ces,
        [Description("slk")]
        slk,
        [Description("Urdu")]
        urd,
        [Description("Aymara")]
        aym,
        [Description("Quechua")]
        que,
        [Description("Greenlandic")]
        kal,
        [Description("Hungarian")]
        hun,
        [Description("Comorian")]
        zdj,
        [Description("Bengali")]
        ben,
        [Description("Tokelauan")]
        tkl,
        [Description("Fijian")]
        fij,
        [Description("Fiji Hindi")]
        hif,
        [Description("Chinese")]
        zho,
        [Description("Maldivian")]
        div,
        [Description("Catalan")]
        cat,
        [Description("Basque")]
        eus,
        [Description("Galician")]
        glc,
        [Description("Irish")]
        gle,
        [Description("Estonian")]
        est,
        [Description("Guaraní")]
        grn,
        [Description("Afrikaans")]
        afr,
        [Description("Southern Ndebele")]
        nbl,
        [Description("Northern Sotho")]
        nso,
        [Description("Southern Sotho")]
        sot,
        [Description("Swazi")]
        ssw,
        [Description("Tswana")]
        tsn,
        [Description("Tsonga")]
        tso,
        [Description("Venda")]
        ven,
        [Description("Xhosa")]
        xho,
        [Description("Zulu")]
        zul,
        [Description("Bislama")]
        bis,
        [Description("Finnish")]
        fin,
        [Description("Swedish")]
        swe,
        [Description("Norfuk")]
        pih,
        [Description("Belizean Creole")]
        bjz,
        [Description("Mongolian")]
        mon,
        [Description("Nepali")]
        nep,
        [Description("Manx")]
        glv,
        [Description("Dzongkha")]
        dzo,
        [Description("Khmer")]
        khm,
        [Description("Haitian Creole")]
        hat,
        [Description("Georgian")]
        kat,
        [Description("Kirundi")]
        run,
        [Description("Mauritian Creole")]
        mfe,
        [Description("Chewa")]
        nya,
        [Description("Hiri Motu")]
        hmo,
        [Description("Tok Pisin")]
        tpi,
        [Description("German")]
        deu,
        [Description("Hebrew")]
        heb,
        [Description("Tamil")]
        tam,
        [Description("Dutch")]
        nld,
        [Description("Uzbek")]
        uzb,
        [Description("Malagasy")]
        mlg,
        [Description("Marshallese")]
        mah,
        [Description("Seychellois Creole")]
        crs,
        [Description("Japanese")]
        jpn,
        [Description("Persian (Farsi)")]
        fas,
        [Description("Maltese")]
        mlt,
        [Description("Korean")]
        kor,
        [Description("Jamaican Patois")]
        jam,
        [Description("Danish")]
        dan,
        [Description("Filipino")]
        fil,
        [Description("Upper Guinea Creole")]
        pov,
        [Description("Herero")]
        her,
        [Description("Khoekhoe")]
        hgm,
        [Description("Kwangali")]
        kwn,
        [Description("Lozi")]
        loz,
        [Description("Ndonga")]
        ndo,
        [Description("Bosnian")]
        bos,
        [Description("Serbian")]
        srp,
        [Description("Montenegrin")]
        cnr,
        [Description("Carolinian")]
        cal,
        [Description("Ukrainian")]
        ukr,
        [Description("Aramaic")]
        arc,
        [Description("Sorani")]
        ckb,
        [Description("Faroese")]
        fao,
        [Description("Gilbertese")]
        gil,
        [Description("Kazakh")]
        kaz,
        [Description("Icelandic")]
        isl,
        [Description("Palauan")]
        pau,
        [Description("Swiss German")]
        gsw,
        [Description("Romansh")]
        roh,
        [Description("Burmese")]
        mya,
        [Description("Thai")]
        tha,
        [Description("Papiamento")]
        pap,
        [Description("Lao")]
        lao,
        [Description("Luxembourgish")]
        ltz,
        [Description("Sango")]
        sag,
        [Description("Guernésiais")]
        nfr,
        [Description("Norwegian Nynorsk")]
        nno,
        [Description("Norwegian Bokmål")]
        nob,
        [Description("Sami")]
        smi,
        [Description("Chibarwe")]
        bwg,
        [Description("Kalanga")]
        kck,
        [Description("Khoisan")]
        khi,
        [Description("Ndau")]
        ndc,
        [Description("Northern Ndebele")]
        nde,
        [Description("Shona")]
        sna,
        [Description("Tonga")]
        toi,
        [Description("Zimbabwean Sign Language")]
        zib,
        [Description("Slovene")]
        slv,
        [Description("Tshiluba")]
        lua,
        [Description("Indonesian")]
        ind,
        [Description("Nauru")]
        nau,
        [Description("Macedonian")]
        mkd,
        [Description("Kinyarwanda")]
        kin,
        [Description("Sinhala")]
        sin,
        
    }
}

