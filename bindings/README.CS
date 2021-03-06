C# NameTag Bindings
======================

Installation
============

Binary C# bindings are available in NameTag binary packages.

To compile C# bindings manually, run make in the bindings/csharp directory,
optionally with the options described in NameTag Installation.


C# Bindings API
===============

NameTag library bindings is available in the Ufal.NameTag namespace.

The bindings is a straightforward conversion of the C++ bindings API. The
bindings requires native C++ library libnametag_csharp (called nametag_csharp on
Windows).

See also C# binding example usage
(https://github.com/ufal/nametag/tree/master/bindings/csharp/examples).


C++ Bindings API
================


Helper Structures
-----------------

  typedef vector<string> Forms;

  struct TokenRange {
    size_t start;
    size_t length;
  };
  typedef vector<TokenRange> TokenRanges;

  struct NamedEntity {
    size_t start;
    size_t length;
    string type;

    NamedEntity();
    NamedEntity(size_t start, size_t length, const string& type);
  };
  typedef vector<NamedEntity> NamedEntities;


Main Classes
------------

  class Version {
   public:
    unsigned major;
    unsigned minor;
    unsigned patch;
    string prerelease;

    static Version current();
  };

  class Tokenizer {
   public:
    virtual void setText(const char* text);
    virtual bool nextSentence(Forms* forms, TokenRanges* tokens);

    static Tokenizer* newVerticalTokenizer();
  };

  class Ner {
    static ner* load(const char* fname);

    virtual void recognize(Forms& forms, NamedEntities& entities) const;

    virtual void entityTypes(Forms& types) const;
    virtual void gazetteers(Forms& gazetteers, Ints& gazetteer_types) const;

    virtual Tokenizer* newTokenizer() const;
  };
