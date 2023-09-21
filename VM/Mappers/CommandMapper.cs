using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Interfaces;
using VM.Translators;

namespace VM.Mappers
{
    internal class CommandMapper : ICommandMapper
    {
        private readonly ITranslateAdd _translateAdd;
        //private readonly ITranslateAnd _translateAnd;
        //private readonly ITranslateCall _translateCall;
        //private readonly ITranslateEq _translateEq;
        //private readonly ITranslateFunction _translateFunction;
        //private readonly ITranslateGoto _translateGoto;
        //private readonly ITranslateGt _translateGt;
        //private readonly ITranslateIfGoto _translateIfGoto;
        //private readonly ITranslateLabel _translateLabel;
        private readonly ITranslateLt _translateLt;
        //private readonly ITranslateNeg _translateNeg;
        //private readonly ITranslateNot _translateNot;
        //private readonly ITranslateOr _translateOr;
        private readonly ITranslatePop _translatePop;
        private readonly ITranslatePush _translatePush;
        //private readonly ITranslateReturn _translateReturn;
        //private readonly ITranslateSub _translateSub;


        public Dictionary<string, Action<StringBuilder>> CommandMap { get; private set; }
        public Dictionary<string, Action<string, string, StringBuilder>> CommandWithLocationAndValueMap { get; private set; }
        public Dictionary<string, Action<string, StringBuilder>> CommandWithLocationMap { get; private set; }


        public CommandMapper(
            ITranslateAdd translateAdd,
            //ITranslateAnd translateAnd,
            //ITranslateCall translateCall,
            //ITranslateEq translateEq,
            //ITranslateFunction translateFunction,
            //ITranslateGoto translateGoto,
            //ITranslateGt translateGt,
            //ITranslateIfGoto translateIfGoto,
            //ITranslateLabel translateLabel,
            ITranslateLt translateLt,
            //ITranslateNeg translateNeg,
            //ITranslateNot translateNot,
            //ITranslateOr translateOr,
            ITranslatePop translatePop,
            ITranslatePush translatePush//,
            //ITranslateReturn translateReturn,
            //ITranslateSub translateSub
        )
        {
            _translateAdd = translateAdd;
            //_translateAnd = translateAnd;
            //_translateCall = translateCall;
            //_translateEq = translateEq;
            //_translateFunction = translateFunction;
            //_translateGoto = translateGoto;
            //_translateGt = translateGt;
            //_translateIfGoto = translateIfGoto;
            //_translateLabel = translateLabel;
            _translateLt = translateLt;
            //_translateNeg = translateNeg;
            //_translateNot = translateNot;
            //_translateOr = translateOr;
            _translatePop = translatePop;
            _translatePush = translatePush;
            //_translateReturn = translateReturn;
            //_translateSub = translateSub;
            InitializeCommandMaps();
        }


        private void InitializeCommandMaps()
        {
            CommandMap = new Dictionary<string, Action<StringBuilder>>
            {
                {"add", _translateAdd.Translate},
                //{"sub", _translateSub.Translate},
                //{"neg", _translateNeg.Translate},
                //{"eq", _translateEq.Translate},
                //{"gt", _translateGt.Translate},
                {"lt", _translateLt.Translate},
                //{"and", _translateAnd.Translate},
                //{"or", _translateOr.Translate},
                //{"not", _translateNot.Translate},
                //{"return", _translateReturn.Translate}
            };

            CommandWithLocationAndValueMap = new Dictionary<string, Action<string, string, StringBuilder>>
            {
                {"push", _translatePush.Translate},
                {"pop", _translatePop.Translate}//,
                //{"function", _translateFunction.Translate},
                //{"call", _translateCall.Translate}
            };

            CommandWithLocationMap = new Dictionary<string, Action<string, StringBuilder>>
            {
                //{"label", _translateLabel.Translate},
                //{"goto", _translateGoto.Translate},
                //{"if-goto", _translateIfGoto.Translate}
            };
        }

    }
}


