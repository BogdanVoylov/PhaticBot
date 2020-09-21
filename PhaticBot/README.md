<h1>Phatic Bot</h1>
<h3>Target framework: .NetCoreApp, Version=v3.1</h3>
<h2>Description</h2>
Program is a console app based on infinit loop. Bot scans with regex user's phrase and responds with random phrase from the list that corresponds to the suited regex.
<h2>Instructions</h2>
if you see error reading dataset then you should change path to dataset ( DATASET_PATH in Program.cs )
<br/>
Dataset consist of themes (each should have unique name) and one "Reserve" theme (Should be always named "Reserve").
"Reserve" theme is used when other themes does not include suitable regex for user input.
<br/> 
Each theme is dictionary where key is regex and value is list of answers.
You can youse c# format syntax like this: <br/>
<code>
<pre>
".*?(?i)(mother|mum|father|daddy|dad|granny).*": [
      "tell me more about your {1}"
    ]
</pre>
</code>
<br/>
<code>{1}</code> stands for second group of your regex (numbering starts from zero).
In this sample <code>{0}</code> is all phrase.<br/>
<h2>Developer Instructions</h2>
You should build PhaticBot with it's static method Build <br/>
<code>
<pre>
IBot bot = Lib.PhaticBot.Build(builder =>
            {
                builder.SetReserve(reserveTheme);
                builder.AddThemes(themes);
            });
</pre>
</code> <br/>
Then to "communicate" with bot you should call <br/>
<code>string ProcessPhrase(string phrase);</code>
<h2>Third Party Dependecies</h2>
Newtosoft.Json/12.0.3 used for parsing dataset.

