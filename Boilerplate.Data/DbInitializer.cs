using Boilerplate.Data.Context;
using Boilerplate.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Boilerplate.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BoilerplateContext context)
        {
            context.Database.EnsureCreated();

            if (context.User.Any())
            {
                return; // DB has been seeded already
            }

            #region Test users
            var users = new List<User>
            {
                new User { Username = "guest", Email = "guest@guest.co", PasswordHash = "guest", IsAdmin = true, IsDeleted = false },
                new User { Username = "minch", Email = "bminchinton0@blogspot.com", PasswordHash = "qsk3", IsAdmin = true, IsDeleted = false },
                new User { Username = "cecca", Email = "ceccersley1@state.tx.us", PasswordHash = "Mnh12", IsAdmin = false, IsDeleted = false },
                new User { Username = "jollo", Email = "jollarenshaw2@4shared.com", PasswordHash = "d4a6", IsAdmin = true, IsDeleted = false },
                new User { Username = "amucklow3", Email = "bpresdee3@shareasale.com", PasswordHash = "PBgtMngboo", IsAdmin = false, IsDeleted = true },
                new User { Username = "pknoble4", Email = "tphippen4@ovh.net", PasswordHash = "6xP3wqvX1", IsAdmin = true, IsDeleted = false },
                new User { Username = "cdayton5", Email = "cbarthorpe5@dmoz.org", PasswordHash = "SopMcKn", IsAdmin = true, IsDeleted = false },
                new User { Username = "scouronne6", Email = "arichardot6@oakley.com", PasswordHash = "xI0dGLqVpwy", IsAdmin = true, IsDeleted = true },
                new User { Username = "kconn7", Email = "vyellowlee7@pcworld.com", PasswordHash = "ElghjKYocji", IsAdmin = true, IsDeleted = false },
                new User { Username = "rcalvie8", Email = "sgraundisson8@tinyurl.com", PasswordHash = "qqQoWD1zr5Em", IsAdmin = true, IsDeleted = false },
                new User { Username = "cnewsham9", Email = "tloveman9@ca.gov", PasswordHash = "GxWNn7", IsAdmin = true, IsDeleted = false },
                new User { Username = "mmccaugheya", Email = "dmccandiea@narod.ru", PasswordHash = "k8oUSKCQG87", IsAdmin = true, IsDeleted = false },
                new User { Username = "iwilkinsb", Email = "cmcinteerb@blogs.com", PasswordHash = "Wv1AVnZw", IsAdmin = false, IsDeleted = true },
                new User { Username = "nschoolcroftc", Email = "rkanwellc@wikispaces.com", PasswordHash = "1coUVN", IsAdmin = false, IsDeleted = true },
                new User { Username = "iheintschd", Email = "dcloughtond@dmoz.org", PasswordHash = "imaLRMyiw", IsAdmin = false, IsDeleted = true },
                new User { Username = "rkubistae", Email = "manselme@walmart.com", PasswordHash = "VwYmiFFbe", IsAdmin = false, IsDeleted = false },
                new User { Username = "juccellif", Email = "mpickworthf@accuweather.com", PasswordHash = "xRVfnIObm", IsAdmin = false, IsDeleted = false },
                new User { Username = "beymerg", Email = "csucklingg@washington.edu", PasswordHash = "pTEtRV588V", IsAdmin = true, IsDeleted = false },
                new User { Username = "sandreassonh", Email = "enuscheh@biglobe.ne.jp", PasswordHash = "FFSsG60xj2", IsAdmin = true, IsDeleted = true },
                new User { Username = "challsi", Email = "mmcsporrini@elpais.com", PasswordHash = "SPJvwFnZ", IsAdmin = false, IsDeleted = true },
                new User { Username = "asantarellij", Email = "nkockj@hatena.ne.jp", PasswordHash = "Q5p2n2Yeha", IsAdmin = true, IsDeleted = false },
                new User { Username = "afurmedgek", Email = "tmillek@dion.ne.jp", PasswordHash = "g4CIPyIMuT14", IsAdmin = false, IsDeleted = true },
                new User { Username = "lsterryl", Email = "parmingerl@imdb.com", PasswordHash = "jur7wn19Ik5", IsAdmin = true, IsDeleted = true },
                new User { Username = "ngogartym", Email = "spicoppm@google.com.br", PasswordHash = "tBBBQF", IsAdmin = false, IsDeleted = true },
                new User { Username = "kghiroldin", Email = "mwinchcombn@i2i.jp", PasswordHash = "i1hSoCstpG", IsAdmin = true, IsDeleted = true },
                new User { Username = "rpuzeyo", Email = "rjayso@unblog.fr", PasswordHash = "KYNKbWH0S", IsAdmin = true, IsDeleted = true },
                new User { Username = "gferrarinip", Email = "vkordtp@marketwatch.com", PasswordHash = "o7W0pyRP0suy", IsAdmin = true, IsDeleted = true },
                new User { Username = "kscothorneq", Email = "sfarnieq@comsenz.com", PasswordHash = "GENFBY53O", IsAdmin = true, IsDeleted = false },
                new User { Username = "jkinforthr", Email = "iiwanickir@umn.edu", PasswordHash = "UiTks943Dldx", IsAdmin = false, IsDeleted = true },
                new User { Username = "dmilroys", Email = "mladsons@hibu.com", PasswordHash = "P74BwgNNv6E6", IsAdmin = true, IsDeleted = true },
                new User { Username = "hmabbet", Email = "vrenshallt@quantcast.com", PasswordHash = "cCRIgnjfRa", IsAdmin = false, IsDeleted = false },
                new User { Username = "lstubbsu", Email = "ecammisu@pcworld.com", PasswordHash = "p56zNvDDNdfC", IsAdmin = true, IsDeleted = true },
                new User { Username = "ccurseyv", Email = "nrodsonv@uol.com.br", PasswordHash = "w4QJ8h833vE", IsAdmin = false, IsDeleted = true },
                new User { Username = "dcoburnw", Email = "rbriddenw@zdnet.com", PasswordHash = "tZQfpDG6In", IsAdmin = false, IsDeleted = true },
                new User { Username = "nnaylorx", Email = "bkitcatx@simplemachines.org", PasswordHash = "NrgyhLse5XNe", IsAdmin = false, IsDeleted = false },
                new User { Username = "spahly", Email = "jemsdeny@theatlantic.com", PasswordHash = "sgXkNY", IsAdmin = false, IsDeleted = true },
                new User { Username = "gsmurfittz", Email = "vmorcombez@alibaba.com", PasswordHash = "HNN0FehNNKN", IsAdmin = true, IsDeleted = true },
                new User { Username = "dfrantzen10", Email = "jhamp10@vistaprint.com", PasswordHash = "HocyKSiVN9A", IsAdmin = true, IsDeleted = true },
                new User { Username = "mmclean11", Email = "athickpenny11@seesaa.net", PasswordHash = "3V5Oe5", IsAdmin = true, IsDeleted = true },
                new User { Username = "gstreight12", Email = "rcoulthard12@dyndns.org", PasswordHash = "tQf50G", IsAdmin = true, IsDeleted = true },
                new User { Username = "umatyushkin13", Email = "criach13@newsvine.com", PasswordHash = "avDHwetNb8f", IsAdmin = true, IsDeleted = true },
                new User { Username = "aplatt14", Email = "oseckom14@alexa.com", PasswordHash = "rqN81nEN", IsAdmin = true, IsDeleted = false },
                new User { Username = "nmicheu15", Email = "srawe15@go.com", PasswordHash = "tYX474", IsAdmin = false, IsDeleted = false },
                new User { Username = "tgheorghescu16", Email = "rritmeyer16@nsw.gov.au", PasswordHash = "kPxGKrA6", IsAdmin = false, IsDeleted = true },
                new User { Username = "firnys17", Email = "trustan17@latimes.com", PasswordHash = "eGMUp80G9Wi", IsAdmin = true, IsDeleted = true },
                new User { Username = "twigfield18", Email = "mwoltering18@admin.ch", PasswordHash = "xCVIFAzKtq", IsAdmin = true, IsDeleted = true },
                new User { Username = "sreucastle19", Email = "tcaroli19@altervista.org", PasswordHash = "zVVIAUP416MJ", IsAdmin = false, IsDeleted = true },
                new User { Username = "ealenichicov1a", Email = "tkitteridge1a@state.gov", PasswordHash = "iW7GpKkrPICn", IsAdmin = false, IsDeleted = false },
                new User { Username = "tfurmston1b", Email = "kpoulgreen1b@canalblog.com", PasswordHash = "DRyh1rrRHZc", IsAdmin = true, IsDeleted = false },
                new User { Username = "hdolan1c", Email = "rcaven1c@jugem.jp", PasswordHash = "pR2Llo", IsAdmin = false, IsDeleted = true },
                new User { Username = "dheard1d", Email = "wlittrell1d@example.com", PasswordHash = "a0IBb9A3X", IsAdmin = true, IsDeleted = false },
                new User { Username = "fozanne1e", Email = "bspringall1e@usatoday.com", PasswordHash = "h09mnUQda", IsAdmin = false, IsDeleted = false },
                new User { Username = "eleney1f", Email = "rmckellen1f@chron.com", PasswordHash = "XXW6qMRq", IsAdmin = true, IsDeleted = false },
                new User { Username = "jbleything1g", Email = "mdonaghy1g@godaddy.com", PasswordHash = "t61JmJp0", IsAdmin = true, IsDeleted = true },
                new User { Username = "dhearsum1h", Email = "hclewley1h@artisteer.com", PasswordHash = "UpaoEUlvwS", IsAdmin = true, IsDeleted = true },
                new User { Username = "peager1i", Email = "omcdougall1i@shinystat.com", PasswordHash = "h4eDFbP", IsAdmin = false, IsDeleted = true },
                new User { Username = "sgaiger1j", Email = "ewitcher1j@zimbio.com", PasswordHash = "go3xJU", IsAdmin = false, IsDeleted = false },
                new User { Username = "nmoorcraft1k", Email = "phanmer1k@virginia.edu", PasswordHash = "tDRKrHZGL8Qv", IsAdmin = false, IsDeleted = true },
                new User { Username = "bdurning1l", Email = "bborg1l@dmoz.org", PasswordHash = "MabzZ0kSpc", IsAdmin = false, IsDeleted = true },
                new User { Username = "lmckinie1m", Email = "dtadman1m@drupal.org", PasswordHash = "HyaZqWuS1u", IsAdmin = false, IsDeleted = false },
                new User { Username = "ohaseley1n", Email = "rhanmore1n@princeton.edu", PasswordHash = "geO4aTUbXi3", IsAdmin = false, IsDeleted = true },
                new User { Username = "rskingley1o", Email = "lvasilyonok1o@ameblo.jp", PasswordHash = "jBLugTCpi", IsAdmin = false, IsDeleted = false },
                new User { Username = "nrillett1p", Email = "rshawley1p@tiny.cc", PasswordHash = "oAKvS9Ksh", IsAdmin = true, IsDeleted = false },
                new User { Username = "vgrandham1q", Email = "gpapen1q@yale.edu", PasswordHash = "vwo8cw2", IsAdmin = false, IsDeleted = true },
                new User { Username = "dgalloway1r", Email = "mwhiffin1r@g.co", PasswordHash = "xxDQKmEhMB9f", IsAdmin = true, IsDeleted = false },
                new User { Username = "ischole1s", Email = "hchafer1s@pen.io", PasswordHash = "IkmNCMnMWW7", IsAdmin = true, IsDeleted = false },
                new User { Username = "bastlatt1t", Email = "acreebo1t@plala.or.jp", PasswordHash = "2SzlNj", IsAdmin = true, IsDeleted = false },
                new User { Username = "mcuredell1u", Email = "bchipman1u@narod.ru", PasswordHash = "1BWWBks27", IsAdmin = false, IsDeleted = false },
                new User { Username = "ehorley1v", Email = "mstrover1v@sakura.ne.jp", PasswordHash = "H8scsQ99uiri", IsAdmin = false, IsDeleted = true },
                new User { Username = "hkelston1w", Email = "mhowitt1w@cloudflare.com", PasswordHash = "UVTufP7R", IsAdmin = false, IsDeleted = false },
                new User { Username = "jbavester1x", Email = "lmcgaugan1x@storify.com", PasswordHash = "Blh3ZFbIAofC", IsAdmin = true, IsDeleted = false },
                new User { Username = "cfleckness1y", Email = "bmcbain1y@google.it", PasswordHash = "gW9GhZa", IsAdmin = false, IsDeleted = false },
                new User { Username = "mbowfin1z", Email = "fskarin1z@netvibes.com", PasswordHash = "cJHLZt", IsAdmin = true, IsDeleted = false },
                new User { Username = "sdionsetto20", Email = "hberrill20@slideshare.net", PasswordHash = "5vaKa15ZnRF", IsAdmin = false, IsDeleted = true },
                new User { Username = "alempertz21", Email = "cperl21@mozilla.org", PasswordHash = "b77AVf", IsAdmin = false, IsDeleted = true },
                new User { Username = "cgaule22", Email = "elaverty22@ca.gov", PasswordHash = "YXgHWpem", IsAdmin = true, IsDeleted = true },
                new User { Username = "crubinov23", Email = "ntudhope23@cargocollective.com", PasswordHash = "cb7hYd", IsAdmin = false, IsDeleted = false },
                new User { Username = "kchillingworth24", Email = "adelacourt24@berkeley.edu", PasswordHash = "O5x1hDJe44", IsAdmin = false, IsDeleted = true },
                new User { Username = "torhrt25", Email = "jzamora25@godaddy.com", PasswordHash = "i1zleYXtkvKi", IsAdmin = false, IsDeleted = false },
                new User { Username = "ctrehearne26", Email = "pmcmeekan26@un.org", PasswordHash = "K5n1u4f", IsAdmin = false, IsDeleted = true },
                new User { Username = "mcarus27", Email = "ecatherick27@ucsd.edu", PasswordHash = "EXqkMrU", IsAdmin = true, IsDeleted = false },
                new User { Username = "cfaragher28", Email = "ehousden28@nifty.com", PasswordHash = "7O3rLLJ", IsAdmin = false, IsDeleted = false },
                new User { Username = "wkeefe29", Email = "bcutford29@fc2.com", PasswordHash = "TjTM90wmlMeq", IsAdmin = false, IsDeleted = true },
                new User { Username = "hree2a", Email = "llambourne2a@i2i.jp", PasswordHash = "UeHl7exh3qM5", IsAdmin = true, IsDeleted = true },
                new User { Username = "rserot2b", Email = "kwestpfel2b@census.gov", PasswordHash = "xo5h9jKGP", IsAdmin = true, IsDeleted = true },
                new User { Username = "gmassinger2c", Email = "cwaterstone2c@nba.com", PasswordHash = "NqVx9LD", IsAdmin = true, IsDeleted = false },
                new User { Username = "operrycost2d", Email = "mstarsmeare2d@spiegel.de", PasswordHash = "Cdo9OtDc2Zw", IsAdmin = false, IsDeleted = false },
                new User { Username = "shurley2e", Email = "bguerrier2e@dedecms.com", PasswordHash = "8skjF4i", IsAdmin = false, IsDeleted = false },
                new User { Username = "mpollicott2f", Email = "kluno2f@mtv.com", PasswordHash = "lyDZbqLBZ", IsAdmin = false, IsDeleted = false },
                new User { Username = "acrisford2g", Email = "lshawcross2g@soup.io", PasswordHash = "TBesY7x2U", IsAdmin = false, IsDeleted = false },
                new User { Username = "lloyns2h", Email = "calleburton2h@dyndns.org", PasswordHash = "qwh6sk9", IsAdmin = true, IsDeleted = true },
                new User { Username = "pnuttall2i", Email = "kskylett2i@sina.com.cn", PasswordHash = "UysVkD6FRvd", IsAdmin = false, IsDeleted = true },
                new User { Username = "astack2j", Email = "dchampken2j@ovh.net", PasswordHash = "I6PL4y", IsAdmin = false, IsDeleted = false },
                new User { Username = "inevison2k", Email = "streweela2k@homestead.com", PasswordHash = "I9GGEdWT3a", IsAdmin = true, IsDeleted = true },
                new User { Username = "agrabert2l", Email = "cgiraldo2l@cmu.edu", PasswordHash = "WS6op37SS9W", IsAdmin = false, IsDeleted = true },
                new User { Username = "ethom2m", Email = "gmeo2m@cdbaby.com", PasswordHash = "rgIMSyqzDKLu", IsAdmin = true, IsDeleted = true },
                new User { Username = "cferreres2n", Email = "kreichert2n@lulu.com", PasswordHash = "m6DRdmDZxI", IsAdmin = false, IsDeleted = true },
                new User { Username = "dbilam2o", Email = "braun2o@psu.edu", PasswordHash = "wVLQSQF9D5q", IsAdmin = false, IsDeleted = false },
                new User { Username = "slevis2p", Email = "eadhams2p@a8.net", PasswordHash = "FyHHnHp", IsAdmin = true, IsDeleted = true },
                new User { Username = "gblackston2q", Email = "eyegorev2q@sina.com.cn", PasswordHash = "GstIIxB97", IsAdmin = false, IsDeleted = false }
            };
            #endregion

            context.User.AddRange(users);            
            context.SaveChanges();
        }
    }
}
