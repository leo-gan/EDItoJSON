{
  "ISASegment": {
    "PositionalElements": [
      {
        "Position": null,
        "Lenght": 2,
        "Name": "Authorization Qualifier",
        "DefaultValue": "00",
        "Value": "00"
      },
      {
        "Position": null,
        "Lenght": 10,
        "Name": "Authorization Information",
        "DefaultValue": "",
        "Value": ""
      },
      {
        "Position": null,
        "Lenght": 2,
        "Name": "Security Qualifier",
        "DefaultValue": "00",
        "Value": "00"
      },
      {
        "Position": null,
        "Lenght": 10,
        "Name": "Security Information",
        "DefaultValue": "",
        "Value": ""
      },
      {
        "Position": null,
        "Lenght": 2,
        "Name": "Sender Qualifier",
        "DefaultValue": "",
        "Value": "ZZ"
      },
      {
        "Position": null,
        "Lenght": 15,
        "Name": "Sender Identifier",
        "DefaultValue": "",
        "Value": "ABCCOM"
      },
      {
        "Position": null,
        "Lenght": 2,
        "Name": "Receiver Qualifier",
        "DefaultValue": "",
        "Value": "ZZ"
      },
      {
        "Position": null,
        "Lenght": 15,
        "Name": "Receiver Identifier",
        "DefaultValue": "",
        "Value": "99999999"
      },
      {
        "Position": null,
        "Lenght": 6,
        "Name": "Interchange Date",
        "DefaultValue": null,
        "Value": "040315"
      },
      {
        "Position": null,
        "Lenght": 4,
        "Name": "Interchange Time",
        "DefaultValue": null,
        "Value": "1005"
      },
      {
        "Position": null,
        "Lenght": 1,
        "Name": "Standard Identifier",
        "DefaultValue": "U",
        "Value": "U"
      },
      {
        "Position": null,
        "Lenght": 5,
        "Name": "Control Version",
        "DefaultValue": null,
        "Value": "00401"
      },
      {
        "Position": null,
        "Lenght": 9,
        "Name": "Interchange Control Number",
        "DefaultValue": null,
        "Value": "004075123"
      },
      {
        "Position": null,
        "Lenght": 1,
        "Name": "Technical Acknowledgment Required",
        "DefaultValue": "",
        "Value": "0"
      },
      {
        "Position": null,
        "Lenght": 1,
        "Name": "Usage Indicator",
        "DefaultValue": "T",
        "Value": "P"
      },
      {
        "Position": null,
        "Lenght": 2,
        "Name": "Component Separator and Segment Terminator",
        "DefaultValue": ">~",
        "Value": ":"
      }
    ],
    "Name": "ISA",
    "AsString": "ISA*00**00**ZZ*ABCCOM*ZZ*99999999*040315*1005*U*00401*004075123*0*P*:",
    "Elements": [
      "00",
      "",
      "00",
      "",
      "ZZ",
      "ABCCOM",
      "ZZ",
      "99999999",
      "040315",
      "1005",
      "U",
      "00401",
      "004075123",
      "0",
      "P",
      ":"
    ]
  },
  "IEASegment": {
    "Elements": [
      {
        "Name": "Number of Groups",
        "DefaultValue": null,
        "Value": "1"
      },
      {
        "Name": "Interchange Control Number",
        "DefaultValue": null,
        "Value": "004075123"
      }
    ],
    "Name": "IEA",
    "AsString": "IEA*1*004075123"
  },
  "Groups": [
    {
      "Documents": [
        {
          "Segments": [
            {
              "Name": "BPR",
              "AsString": "BPR*H*5.75*C*NON************20110315",
              "Elements": [
                "H",
                "5.75",
                "C",
                "NON",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "20110315"
              ]
            },
            {
              "Name": "TRN",
              "AsString": "TRN*1*A04B001017.07504*1346000128",
              "Elements": [
                "1",
                "A04B001017.07504",
                "1346000128"
              ]
            },
            {
              "Name": "DTM",
              "AsString": "DTM*405*20110308",
              "Elements": [
                "405",
                "20110308"
              ]
            },
            {
              "Name": "N1",
              "AsString": "N1*PR*ASHTABULA COUNTY ADAMH BD*XX*6457839886",
              "Elements": [
                "PR",
                "ASHTABULA COUNTY ADAMH BD",
                "XX",
                "6457839886"
              ]
            },
            {
              "Name": "N3",
              "AsString": "N3*4817 STATE ROAD SUITE 203",
              "Elements": [
                "4817 STATE ROAD SUITE 203"
              ]
            },
            {
              "Name": "N4",
              "AsString": "N4*ASHTABULA*OH*44004",
              "Elements": [
                "ASHTABULA",
                "OH",
                "44004"
              ]
            },
            {
              "Name": "PER",
              "AsString": "PER*CX*Help Desk*TE*8885672351",
              "Elements": [
                "CX",
                "Help Desk",
                "TE",
                "8885672351"
              ]
            },
            {
              "Name": "N1",
              "AsString": "N1*PE*LAKE AREA RECOVERY CENTER*FI*346608640",
              "Elements": [
                "PE",
                "LAKE AREA RECOVERY CENTER",
                "FI",
                "346608640"
              ]
            },
            {
              "Name": "N3",
              "AsString": "N3*2801 C. COURT",
              "Elements": [
                "2801 C. COURT"
              ]
            },
            {
              "Name": "N4",
              "AsString": "N4*ASHTABULA*OH*44004",
              "Elements": [
                "ASHTABULA",
                "OH",
                "44004"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*PQ*1017",
              "Elements": [
                "PQ",
                "1017"
              ]
            },
            {
              "Name": "LX",
              "AsString": "LX*1",
              "Elements": [
                "1"
              ]
            },
            {
              "Name": "CLP",
              "AsString": "CLP*444444*1*56.70*56.52*0*MC*0000000655555555*53",
              "Elements": [
                "444444",
                "1",
                "56.70",
                "56.52",
                "0",
                "MC",
                "0000000655555555",
                "53"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*QC*1*FUDD*ELMER*S***MI*1333333",
              "Elements": [
                "QC",
                "1",
                "FUDD",
                "ELMER",
                "S",
                "",
                "",
                "MI",
                "1333333"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*82*2*WECOVERWY SVCS*****FI*346608640",
              "Elements": [
                "82",
                "2",
                "WECOVERWY SVCS",
                "",
                "",
                "",
                "",
                "FI",
                "346608640"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*F8*A76B04054",
              "Elements": [
                "F8",
                "A76B04054"
              ]
            },
            {
              "Name": "SVC",
              "AsString": "SVC*HC:H0005:HF:H9*56.70*56.52**6",
              "Elements": [
                "HC:H0005:HF:H9",
                "56.70",
                "56.52",
                "",
                "6"
              ]
            },
            {
              "Name": "DTM",
              "AsString": "DTM*472*20110205",
              "Elements": [
                "472",
                "20110205"
              ]
            },
            {
              "Name": "CAS",
              "AsString": "CAS*CO*42*0.18*0",
              "Elements": [
                "CO",
                "42",
                "0.18",
                "0"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*6R*444444",
              "Elements": [
                "6R",
                "444444"
              ]
            },
            {
              "Name": "CLP",
              "AsString": "CLP*999999*4*25.95*0*25.95*13*0000000555555555*11",
              "Elements": [
                "999999",
                "4",
                "25.95",
                "0",
                "25.95",
                "13",
                "0000000555555555",
                "11"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*QC*1*SAM*YOSEMITE*A***MI*3333333",
              "Elements": [
                "QC",
                "1",
                "SAM",
                "YOSEMITE",
                "A",
                "",
                "",
                "MI",
                "3333333"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*82*2*ACME AGENCY*****FI*310626223",
              "Elements": [
                "82",
                "2",
                "ACME AGENCY",
                "",
                "",
                "",
                "",
                "FI",
                "310626223"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*F8*H57B10401",
              "Elements": [
                "F8",
                "H57B10401"
              ]
            },
            {
              "Name": "SVC",
              "AsString": "SVC*ZZ:M2200:HE*25.95*0**1",
              "Elements": [
                "ZZ:M2200:HE",
                "25.95",
                "0",
                "",
                "1"
              ]
            },
            {
              "Name": "DTM",
              "AsString": "DTM*472*20021224",
              "Elements": [
                "472",
                "20021224"
              ]
            },
            {
              "Name": "CAS",
              "AsString": "CAS*CR*18*25.95*0",
              "Elements": [
                "CR",
                "18",
                "25.95",
                "0"
              ]
            },
            {
              "Name": "CAS",
              "AsString": "CAS*CO*42*0*0",
              "Elements": [
                "CO",
                "42",
                "0",
                "0"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*6R*999999",
              "Elements": [
                "6R",
                "999999"
              ]
            },
            {
              "Name": "CLP",
              "AsString": "CLP*888888*4*162.13*0*162.13*MC*0000000456789123*11",
              "Elements": [
                "888888",
                "4",
                "162.13",
                "0",
                "162.13",
                "MC",
                "0000000456789123",
                "11"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*QC*1*SQUAREPANTS*BOB****MI*2222222",
              "Elements": [
                "QC",
                "1",
                "SQUAREPANTS",
                "BOB",
                "",
                "",
                "",
                "MI",
                "2222222"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*82*2*BIKINI AGENCY*****FI*310626223",
              "Elements": [
                "82",
                "2",
                "BIKINI AGENCY",
                "",
                "",
                "",
                "",
                "FI",
                "310626223"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*F8*H57B10401",
              "Elements": [
                "F8",
                "H57B10401"
              ]
            },
            {
              "Name": "SVC",
              "AsString": "SVC*ZZ:M151000:F0*162.13*0**1.9",
              "Elements": [
                "ZZ:M151000:F0",
                "162.13",
                "0",
                "",
                "1.9"
              ]
            },
            {
              "Name": "DTM",
              "AsString": "DTM*472*20020920",
              "Elements": [
                "472",
                "20020920"
              ]
            },
            {
              "Name": "CAS",
              "AsString": "CAS*CO*29*162.13*0*42*0*0",
              "Elements": [
                "CO",
                "29",
                "162.13",
                "0",
                "42",
                "0",
                "0"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*6R*888888",
              "Elements": [
                "6R",
                "888888"
              ]
            },
            {
              "Name": "CLP",
              "AsString": "CLP*111111*2*56.52*18.88*0*13*0000000644444444*53",
              "Elements": [
                "111111",
                "2",
                "56.52",
                "18.88",
                "0",
                "13",
                "0000000644444444",
                "53"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*QC*1*LEGHORN*FOGHORN*P***MI*7777777",
              "Elements": [
                "QC",
                "1",
                "LEGHORN",
                "FOGHORN",
                "P",
                "",
                "",
                "MI",
                "7777777"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*82*2*CHICKENHAWK SVCS*****FI*346608640",
              "Elements": [
                "82",
                "2",
                "CHICKENHAWK SVCS",
                "",
                "",
                "",
                "",
                "FI",
                "346608640"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*F8*A76B04054",
              "Elements": [
                "F8",
                "A76B04054"
              ]
            },
            {
              "Name": "SVC",
              "AsString": "SVC*HC:H0005:HF:H9*56.52*18.88**6",
              "Elements": [
                "HC:H0005:HF:H9",
                "56.52",
                "18.88",
                "",
                "6"
              ]
            },
            {
              "Name": "DTM",
              "AsString": "DTM*472*20031209",
              "Elements": [
                "472",
                "20031209"
              ]
            },
            {
              "Name": "CAS",
              "AsString": "CAS*CO*42*0*0",
              "Elements": [
                "CO",
                "42",
                "0",
                "0"
              ]
            },
            {
              "Name": "CAS",
              "AsString": "CAS*OA*23*37.64*0",
              "Elements": [
                "OA",
                "23",
                "37.64",
                "0"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*6R*111111",
              "Elements": [
                "6R",
                "111111"
              ]
            },
            {
              "Name": "CLP",
              "AsString": "CLP*121212*4*56.52*0*0*13*0000000646464640*53",
              "Elements": [
                "121212",
                "4",
                "56.52",
                "0",
                "0",
                "13",
                "0000000646464640",
                "53"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*QC*1*EXPLORER*DORA****MI*1717171",
              "Elements": [
                "QC",
                "1",
                "EXPLORER",
                "DORA",
                "",
                "",
                "",
                "MI",
                "1717171"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*82*2*SWIPER AGENCY*****FI*346608640",
              "Elements": [
                "82",
                "2",
                "SWIPER AGENCY",
                "",
                "",
                "",
                "",
                "FI",
                "346608640"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*F8*A76B04054",
              "Elements": [
                "F8",
                "A76B04054"
              ]
            },
            {
              "Name": "SVC",
              "AsString": "SVC*HC:H0005:HF:H9*56.52*0**6",
              "Elements": [
                "HC:H0005:HF:H9",
                "56.52",
                "0",
                "",
                "6"
              ]
            },
            {
              "Name": "DTM",
              "AsString": "DTM*472*20031202",
              "Elements": [
                "472",
                "20031202"
              ]
            },
            {
              "Name": "CAS",
              "AsString": "CAS*CO*42*0*0",
              "Elements": [
                "CO",
                "42",
                "0",
                "0"
              ]
            },
            {
              "Name": "CAS",
              "AsString": "CAS*OA*23*57.6*0*23*-1.08*0",
              "Elements": [
                "OA",
                "23",
                "57.6",
                "0",
                "23",
                "-1.08",
                "0"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*6R*121212",
              "Elements": [
                "6R",
                "121212"
              ]
            },
            {
              "Name": "CLP",
              "AsString": "CLP*333333*1*74.61*59.69*14.92*13*0000000688888888*55",
              "Elements": [
                "333333",
                "1",
                "74.61",
                "59.69",
                "14.92",
                "13",
                "0000000688888888",
                "55"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*QC*1*BEAR*YOGI****MI*2222222",
              "Elements": [
                "QC",
                "1",
                "BEAR",
                "YOGI",
                "",
                "",
                "",
                "MI",
                "2222222"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*82*2*JELLYSTONE SVCS*****FI*346608640",
              "Elements": [
                "82",
                "2",
                "JELLYSTONE SVCS",
                "",
                "",
                "",
                "",
                "FI",
                "346608640"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*F8*A76B04054",
              "Elements": [
                "F8",
                "A76B04054"
              ]
            },
            {
              "Name": "SVC",
              "AsString": "SVC*ZZ:A0230:HF*74.61*59.69**1",
              "Elements": [
                "ZZ:A0230:HF",
                "74.61",
                "59.69",
                "",
                "1"
              ]
            },
            {
              "Name": "DTM",
              "AsString": "DTM*472*20110203",
              "Elements": [
                "472",
                "20110203"
              ]
            },
            {
              "Name": "CAS",
              "AsString": "CAS*PR*2*14.92*0",
              "Elements": [
                "PR",
                "2",
                "14.92",
                "0"
              ]
            },
            {
              "Name": "CAS",
              "AsString": "CAS*CO*42*0*0",
              "Elements": [
                "CO",
                "42",
                "0",
                "0"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*6R*333333",
              "Elements": [
                "6R",
                "333333"
              ]
            },
            {
              "Name": "CLP",
              "AsString": "CLP*777777*25*136.9*0*0*13*0000000622222222*53",
              "Elements": [
                "777777",
                "25",
                "136.9",
                "0",
                "0",
                "13",
                "0000000622222222",
                "53"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*QC*1*BIRD*TWEETY*M***MI*4444444",
              "Elements": [
                "QC",
                "1",
                "BIRD",
                "TWEETY",
                "M",
                "",
                "",
                "MI",
                "4444444"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*82*2*GRANNY AGENCY*****FI*340716747",
              "Elements": [
                "82",
                "2",
                "GRANNY AGENCY",
                "",
                "",
                "",
                "",
                "FI",
                "340716747"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*F8*A76B03293",
              "Elements": [
                "F8",
                "A76B03293"
              ]
            },
            {
              "Name": "SVC",
              "AsString": "SVC*HC:H0015:HF:99:H9*136.9*0**1",
              "Elements": [
                "HC:H0015:HF:99:H9",
                "136.9",
                "0",
                "",
                "1"
              ]
            },
            {
              "Name": "DTM",
              "AsString": "DTM*472*20030911",
              "Elements": [
                "472",
                "20030911"
              ]
            },
            {
              "Name": "CAS",
              "AsString": "CAS*PI*104*136.72*0",
              "Elements": [
                "PI",
                "104",
                "136.72",
                "0"
              ]
            },
            {
              "Name": "CAS",
              "AsString": "CAS*CO*42*0.18*0",
              "Elements": [
                "CO",
                "42",
                "0.18",
                "0"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*6R*777777",
              "Elements": [
                "6R",
                "777777"
              ]
            },
            {
              "Name": "CLP",
              "AsString": "CLP*123456*22*-42.58*-42.58*0*13*0000000657575757*11",
              "Elements": [
                "123456",
                "22",
                "-42.58",
                "-42.58",
                "0",
                "13",
                "0000000657575757",
                "11"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*QC*1*SIMPSON*HOMER****MI*8787888",
              "Elements": [
                "QC",
                "1",
                "SIMPSON",
                "HOMER",
                "",
                "",
                "",
                "MI",
                "8787888"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*82*2*DOH GROUP*****FI*310626223",
              "Elements": [
                "82",
                "2",
                "DOH GROUP",
                "",
                "",
                "",
                "",
                "FI",
                "310626223"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*F8*A57B04033",
              "Elements": [
                "F8",
                "A57B04033"
              ]
            },
            {
              "Name": "SVC",
              "AsString": "SVC*HC:H0036:GT:UK*-42.58*-42.58**-2",
              "Elements": [
                "HC:H0036:GT:UK",
                "-42.58",
                "-42.58",
                "",
                "-2"
              ]
            },
            {
              "Name": "DTM",
              "AsString": "DTM*472*20110102",
              "Elements": [
                "472",
                "20110102"
              ]
            },
            {
              "Name": "CAS",
              "AsString": "CAS*CR*141*0*0*42*0*0*22*0*0",
              "Elements": [
                "CR",
                "141",
                "0",
                "0",
                "42",
                "0",
                "0",
                "22",
                "0",
                "0"
              ]
            },
            {
              "Name": "CAS",
              "AsString": "CAS*OA*141*0*0",
              "Elements": [
                "OA",
                "141",
                "0",
                "0"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*6R*123456",
              "Elements": [
                "6R",
                "123456"
              ]
            },
            {
              "Name": "CLP",
              "AsString": "CLP*090909*22*-86.76*-86.76*0*MC*0000000648484848*53",
              "Elements": [
                "090909",
                "22",
                "-86.76",
                "-86.76",
                "0",
                "MC",
                "0000000648484848",
                "53"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*QC*1*DUCK*DAFFY*W***MI*1245849",
              "Elements": [
                "QC",
                "1",
                "DUCK",
                "DAFFY",
                "W",
                "",
                "",
                "MI",
                "1245849"
              ]
            },
            {
              "Name": "NM1",
              "AsString": "NM1*82*2*ABTHSOLUTE HELP*****FI*346608640",
              "Elements": [
                "82",
                "2",
                "ABTHSOLUTE HELP",
                "",
                "",
                "",
                "",
                "FI",
                "346608640"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*F8*A76B04054",
              "Elements": [
                "F8",
                "A76B04054"
              ]
            },
            {
              "Name": "SVC",
              "AsString": "SVC*HC:H0004:HF:H9*-86.76*-86.76**-4",
              "Elements": [
                "HC:H0004:HF:H9",
                "-86.76",
                "-86.76",
                "",
                "-4"
              ]
            },
            {
              "Name": "DTM",
              "AsString": "DTM*472*20110210",
              "Elements": [
                "472",
                "20110210"
              ]
            },
            {
              "Name": "CAS",
              "AsString": "CAS*CR*22*0*0*42*0*0",
              "Elements": [
                "CR",
                "22",
                "0",
                "0",
                "42",
                "0",
                "0"
              ]
            },
            {
              "Name": "CAS",
              "AsString": "CAS*OA*22*0*0",
              "Elements": [
                "OA",
                "22",
                "0",
                "0"
              ]
            },
            {
              "Name": "REF",
              "AsString": "REF*6R*090909",
              "Elements": [
                "6R",
                "090909"
              ]
            },
            {
              "Name": "LQ",
              "AsString": "LQ*HE*MA92",
              "Elements": [
                "HE",
                "MA92"
              ]
            }
          ],
          "SESegment": {
            "Elements": [
              {
                "Name": "Segment Counter",
                "DefaultValue": null,
                "Value": "93"
              },
              {
                "Name": "Control Number",
                "DefaultValue": null,
                "Value": "07504123"
              }
            ],
            "Name": "SE",
            "AsString": "SE*93*07504123"
          },
          "STSegment": {
            "Elements": [
              {
                "Name": "Document Identifier",
                "DefaultValue": null,
                "Value": "835"
              },
              {
                "Name": "Control Number",
                "DefaultValue": null,
                "Value": "07504123"
              }
            ],
            "Name": "ST",
            "AsString": "ST*835*07504123"
          }
        }
      ],
      "GESegment": {
        "Elements": [
          {
            "Name": "Number of Documents",
            "DefaultValue": null,
            "Value": "1"
          },
          {
            "Name": "Group Control Number",
            "DefaultValue": null,
            "Value": "1"
          }
        ],
        "Name": "GE",
        "AsString": "GE*1*1"
      },
      "GSSegment": {
        "Elements": [
          {
            "Name": "Functional Identifier Code",
            "DefaultValue": null,
            "Value": "HP"
          },
          {
            "Name": "Sender Identifier",
            "DefaultValue": null,
            "Value": "ABCCOM"
          },
          {
            "Name": "Receiver Identifier",
            "DefaultValue": null,
            "Value": "01017"
          },
          {
            "Name": "Date",
            "DefaultValue": null,
            "Value": "20110315"
          },
          {
            "Name": "Time",
            "DefaultValue": null,
            "Value": "1005"
          },
          {
            "Name": "Group Control Number",
            "DefaultValue": null,
            "Value": "1"
          },
          {
            "Name": "Agency Code",
            "DefaultValue": null,
            "Value": "X"
          },
          {
            "Name": "Version identification value",
            "DefaultValue": null,
            "Value": "005010X091A1"
          }
        ],
        "Name": "GS",
        "AsString": "GS*HP*ABCCOM*01017*20110315*1005*1*X*005010X091A1"
      }
    }
  ],
  "SegmentSeparator": "~",
  "DataElementSeparator": "*",
  "DataComponentSeparator": ":"
}