# MEFで同一アセンブリの複数バージョンをロードする

バージョンアップにより複数のコントラクト用アセンブリが出荷されている場合にアプリでそれら複数バージョンの読み込み可否を確認する。また厳密名やバインドリダイレクト有無による違いも確認する。



## Visual Studio プロジェクト構成

プロジェクトの種類と役割は以下の通り。

| プロジェクト         | 役割                                                         |
| -------------------- | ------------------------------------------------------------ |
| My.Console.Framework | 確認用コンソールアプリ (.NET Framework)                      |
| My.Console.NetCore   | 確認用コンソールアプリ (.NET Core)                           |
| My.Contract.V1       | プラグインのコントラクト v1 \| IPlugin インターフェイス のみ |
| My.Contract.V2       | プラグインのコントラクト v2 \| IPlugin2 インターフェイス 追加 |
| My.PlugIn            | コントラクトを実装したプラグイン                             |



## Visual Studio ビルド構成

Visual Studio ソリューションやプロジェクトのビルド構成ごとに、バージョンを表すコンパイルシンボルを定義し、それに応じて C# コードの ` #if` プリプロセッサディレクティブや csproj 内の Condition 属性で切り替えて参照するコントラクトやプラグインを切り替える。



**My.Console のビルド構成**

| ビルド構成名 | アプリ のコントラクト参照 (直接的) | ロードするプラグインが参照するコントラクト (間接的) |
| ------------ | ---------------------------------- | --------------------------------------------------- |
| V2_V1        | V2                                 | V1                                                  |
| V1_V2        | V1                                 | V2                                                  |
| V2_V2        | V2                                 | V2                                                  |



**My.PlugIn のビルド構成**

| 構成名 | My.Contract 参照 |
| ------ | ---------------- |
| V1     | V1               |
| V2     | V2               |



## 厳密名とバインドリダイレクト



厳密名用の署名はコントラクトの csproj ファイルで以下の箇所を False にすると無効になる。

```xml
<SignAssembly>False</SignAssembly>
```



バインドリダイレクトは確認用コンソールアプリの app.config ファイルで以下の箇所をコメントアウトすると無効になる。

``` xml
<runtime>
  <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
    <dependentAssembly>
      <assemblyIdentity name="My.Contract" publicKeyToken="91f9ac04a3ac8b10" culture="neutral" />
      <bindingRedirect oldVersion="1.0.0.0-2.0.0.0" newVersion="2.0.0.0" />
    </dependentAssembly>
  </assemblyBinding>
</runtime>
```



## 結果
要点だけ、V1_V2 のみ不可。厳密名を付けない場合は先に V1 が読み込まれるので V2 は読み込まれない。厳密名を付ければ両方のバージョンが読み込まれるが その中の型 (今回の場合は IPlugIn インターフェイス) は別ものして扱われるので、ユーザー定義型での受け渡しはできない。バインドリダイレクトは未来のバージョンを指定することになりアプリ自体に V2 は含まれない為起動自体不可。.NET Core はそもそもサイドバイサイドローディングはされない。

