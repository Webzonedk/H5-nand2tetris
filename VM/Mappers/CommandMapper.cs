using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Interfaces;

namespace VM.Mappers
{
    internal class CommandMapper : ICommandMapper
    {
        private readonly ITranslateAdd _translateAdd;
        private readonly ITranslateAnd _translateAnd;
        private readonly ITranslateEq _translateEq;
        private readonly ITranslateGt _translateGt;
        private readonly ITranslateLt _translateLt;
        private readonly ITranslateNeg _translateNeg;
        private readonly ITranslateNot _translateNot;
        private readonly ITranslateOr _translateOr;
        private readonly ITranslatePop _translatePop;
        private readonly ITranslatePush _translatePush;
        private readonly ITranslateSub _translateSub;
        //private readonly ITranslateCall _translateCall;
        //private readonly ITranslateFunction _translateFunction;
        //private readonly ITranslateGoto _translateGoto;
        //private readonly ITranslateIfGoto _translateIfGoto;
        //private readonly ITranslateLabel _translateLabel;
        //private readonly ITranslateReturn _translateReturn;


        public Dictionary<string, Action<StringBuilder>> CommandMap { get; private set; }
        public Dictionary<string, Action<int, StringBuilder>> CommandMapWithUniqueCounter { get; private set; }

        public Dictionary<string, Action<string, string, StringBuilder>> CommandWithLocationAndValueMap { get; private set; }
        public Dictionary<string, Action<string, StringBuilder>> CommandWithLocationMap { get; private set; }


        public CommandMapper(
            ITranslateAdd translateAdd,
            ITranslateAnd translateAnd,
            ITranslateEq translateEq,
            ITranslateGt translateGt,
            ITranslateLt translateLt,
            ITranslateNeg translateNeg,
            ITranslateNot translateNot,
            ITranslateOr translateOr,
            ITranslatePop translatePop,
            ITranslatePush translatePush,
            ITranslateSub translateSub
            //ITranslateCall translateCall,
            //ITranslateFunction translateFunction,
            //ITranslateGoto translateGoto,
            //ITranslateIfGoto translateIfGoto,
            //ITranslateLabel translateLabel,
            //ITranslateReturn translateReturn,
        )
        {
            _translateAdd = translateAdd;
            _translateAnd = translateAnd;
            _translateEq = translateEq;
            _translateGt = translateGt;
            _translateLt = translateLt;
            _translateNeg = translateNeg;
            _translateNot = translateNot;
            _translateOr = translateOr;
            _translatePop = translatePop;
            _translatePush = translatePush;
            _translateSub = translateSub;
            //_translateCall = translateCall;
            //_translateFunction = translateFunction;
            //_translateGoto = translateGoto;
            //_translateIfGoto = translateIfGoto;
            //_translateLabel = translateLabel;
            //_translateReturn = translateReturn;
            InitializeCommandMaps();
        }


        private void InitializeCommandMaps()
        {
            CommandMap = new Dictionary<string, Action<StringBuilder>>
            {
                {"add", _translateAdd.Translate},
                {"sub", _translateSub.Translate},
                {"neg", _translateNeg.Translate},


                {"and", _translateAnd.Translate},
                {"or", _translateOr.Translate},
                {"not", _translateNot.Translate},
                //{"return", _translateReturn.Translate}
            };



            CommandMapWithUniqueCounter = new Dictionary<string, Action<int, StringBuilder>>
            {
                {"lt", _translateLt.Translate},
                {"eq", _translateEq.Translate},
                {"gt", _translateGt.Translate},
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


